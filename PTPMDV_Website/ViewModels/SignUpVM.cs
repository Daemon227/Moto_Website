using System.ComponentModel.DataAnnotations;

namespace PTPMDV_Website.ViewModels
{
    public class SignUpVM
    {
        [Key]
        public string? UserId { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [MaxLength(25)]

        public string Username { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Mật Khẩu không được để trống")]
        [MaxLength(20)]
        public string Password { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }
    }
}
