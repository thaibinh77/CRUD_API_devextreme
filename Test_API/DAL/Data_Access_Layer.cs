using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Test_API.Models;

namespace Test_API.DAL
{
    public class Data_Access_Layer
    {
        private readonly IConfiguration configuration;
        SqlConnection conn;
        SqlCommand cmd;

        public Data_Access_Layer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Execute(string procedure)
        {
            conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;
        }


        //       CUSTOMERS
        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> listCustomers = new List<CustomerModel>();

            Execute("sp_GetAllCustomer");

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CustomerModel customer = new CustomerModel();
                customer.customerId = int.Parse(dr["customerId"].ToString());
                customer.fullName = dr["fullName"].ToString();
                customer.Email = dr["Email"].ToString();
                customer.Password = dr["Pass"].ToString();
                customer.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());
                listCustomers.Add(customer);
            }

            conn.Close();

            return listCustomers;
        }

        public List<CustomerModel> UpdateCustomer()
        {
            List<CustomerModel> listCustomers = new List<CustomerModel>();

            Execute("sp_GetAllCustomer");

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CustomerModel customer = new CustomerModel();
                customer.customerId = int.Parse(dr["customerId"].ToString());
                customer.fullName = dr["fullName"].ToString();
                customer.Email = dr["Email"].ToString();
                customer.Password = dr["Pass"].ToString();
                customer.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());
                listCustomers.Add(customer);
            }

            conn.Close();

            return listCustomers;
        }


        //       PRODDUCTS
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> listProducts = new List<ProductModel>();

            Execute("sp_GetAllProduct");

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductModel product = new ProductModel();
                product.productId = int.Parse(dr["productId"].ToString());
                product.productName = dr["productName"].ToString();
                product.imgLink = dr["imgLink"].ToString();
                product.productDescription = dr["productDescription"].ToString();
                product.price = double.Parse(dr["price"].ToString());
                listProducts.Add(product);
            }

            conn.Close();

            return listProducts;
        }

        public ProductModel GetProductById(int productId)
        {
            ProductModel product = null;  // Khởi tạo là null để kiểm tra khi không có sản phẩm

            Execute("sp_GetProductById");
            cmd.Parameters.AddWithValue("@productId", productId);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)  // Kiểm tra xem có dữ liệu trả về không
            {
                product = new ProductModel();  // Khởi tạo ProductModel khi có dữ liệu

                while (dr.Read())
                {
                    product.productId = int.Parse(dr["productId"].ToString());
                    product.productName = dr["productName"].ToString();
                    product.imgLink = dr["imgLink"].ToString();
                    product.productDescription = dr["productDescription"].ToString();
                    product.price = double.Parse(dr["price"].ToString());
                }
            }

            conn.Close();

            return product;  // Trả về null nếu không tìm thấy sản phẩm
        }


        public ProductModel InsertProduct(ProductModel product)
        {
            ProductModel productResult = new ProductModel();

            Execute("sp_InsertProduct");
            cmd.Parameters.AddWithValue("@productName", product.productName);
            string imgLink = "../../Images/" + product.imgLink;
            cmd.Parameters.AddWithValue("@imgLink", imgLink);
            cmd.Parameters.AddWithValue("@productDescription", product.productDescription);
            cmd.Parameters.AddWithValue("@price", product.price);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                productResult.productId = int.Parse(dr["productId"].ToString());
                productResult.productName = dr["productName"].ToString();
                productResult.imgLink = dr["imgLink"].ToString();
                productResult.productDescription = dr["productDescription"].ToString();
                productResult.price = double.Parse(dr["price"].ToString());
            }

            conn.Close();

            return productResult;
        }

        public ProductModel UpdateProduct(ProductModel product)
        {
            ProductModel productResult = new ProductModel();

            Execute("sp_UpdateProduct");
            cmd.Parameters.AddWithValue("@productId", product.productId);
            cmd.Parameters.AddWithValue("@productName", product.productName);
            string imgLink = product.imgLink;
            if (!product.imgLink.Contains("../../Images/"))
            {
                imgLink = "../../Images/" + product.imgLink;
            }
            cmd.Parameters.AddWithValue("@imgLink", imgLink);
            cmd.Parameters.AddWithValue("@productDescription", product.productDescription);
            cmd.Parameters.AddWithValue("@price", product.price);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                productResult.productId = int.Parse(dr["productId"].ToString());
                productResult.productName = dr["productName"].ToString();
                productResult.imgLink = dr["imgLink"].ToString();
                productResult.productDescription = dr["productDescription"].ToString();
                productResult.price = double.Parse(dr["price"].ToString());
            }

            conn.Close();

            return productResult;
        }

        public String DeleteProduct(int productId)
        {
            try
            {
                Execute("sp_DeleteProduct");
                cmd.Parameters.AddWithValue("@productId", productId);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                conn.Close();
                return "Delete success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
