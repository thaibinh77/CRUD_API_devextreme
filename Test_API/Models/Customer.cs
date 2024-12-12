using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test_API.Models
{
    public class CustomerModel
    {
        [Key]
        public int customerId { get; set; }

        [DisplayName("Họ và tên")]
        [Required]
        public string fullName { get; set; } = string.Empty;

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Mật khẩu")]
        [Required]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Ngày sinh")]
        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;


    }
}
