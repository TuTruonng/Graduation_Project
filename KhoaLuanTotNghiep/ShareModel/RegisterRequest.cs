using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareModel
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string FullName { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không hợp lệ")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Mật khẩu từ 6 đến 15 ký tự trong đó có ít nhất một chữ số và một ký tự đặc biệt !")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirm password is required")]
        //[Compare("Password", ErrorMessage = "The Password and Confirm Password do not match.")]
        //public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ !")]
        public string PhoneNumber { get; set; }
    }
}
