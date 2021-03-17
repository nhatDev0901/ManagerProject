using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerProject.Models
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Mật không được để trống")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserLoginModel
    {
        public int? UserID { get; set; }
        public string Username { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}