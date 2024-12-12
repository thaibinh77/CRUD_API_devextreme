using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Test_API.Models
{
    public class ProductModel
    {
        [Key]
        public int productId { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required]
        public string productName { get; set; }

        [DisplayName("Hình ảnh")]
        [Required]
        public string imgLink { get; set; }

        [DisplayName("Mô tả sản phẩm")]
        [Required]
        public string productDescription { get; set; }

        [DisplayName("Giá")]
        [Required]
        public double price { get; set; }

    }
}
