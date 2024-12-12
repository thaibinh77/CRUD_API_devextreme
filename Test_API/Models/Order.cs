using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Test_API.Models
{
    public class OrderModel
    {
        [Key]
        public int orderId { get; set; }

        [DisplayName("Sản phẩm")]
        [Required]
        public string productId { get; set; }

        [DisplayName("Khách hàng")]
        [Required]
        public string customerId { get; set; }

        [DisplayName("Số lượng")]
        [Required]
        public int quantity { get; set; }

        [DisplayName("Đơn giá")]
        [Required]
        public double price { get; set; }

        [DisplayName("Thành tiền")]
        [Required]
        public double totalPrice { get; set; }
    }
}
