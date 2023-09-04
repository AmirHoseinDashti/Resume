using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        public string Password { get; set; }
    }
}
