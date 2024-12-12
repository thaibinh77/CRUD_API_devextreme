using Microsoft.AspNetCore.Mvc;
using Test_API.DAL;
using Test_API.Models;

namespace Test_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly Data_Access_Layer _DAL;

        public ProductController(Data_Access_Layer DAL)
        {
            _DAL = DAL;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            List<ProductModel> listProducts = new List<ProductModel>();
            try
            {
                listProducts = _DAL.GetAllProducts();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(listProducts);
        }

        [HttpGet]
        [Route("GetProductById/{productId}")]
        public IActionResult GetProductById(int productId)
        {
            ProductModel productResult = null;
            try
            {
                productResult = _DAL.GetProductById(productId);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(productResult);
        }

        [HttpPost]
        [Route("InsertProduct")]
        public IActionResult InsertProduct(ProductModel product)
        {
            ProductModel productResult = new ProductModel();
            try
            {
                productResult = _DAL.InsertProduct(product);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(productResult);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(ProductModel product)
        {
            ProductModel productResult = new ProductModel();
            try
            {
                productResult = _DAL.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(productResult);
        }

        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            String result = "";
            try
            {
                result = _DAL.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(result);
        }
    }
}
