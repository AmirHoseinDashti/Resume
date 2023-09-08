using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models
{
    public class ContactViewModel
    {
        public long Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Email { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Message { get; set; }
    }
}
