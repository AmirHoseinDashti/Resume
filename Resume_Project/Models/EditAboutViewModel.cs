using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models
{
    public class EditAboutViewModel
    {
        public long Id { get; set; }

        [DisplayName("عنوان ")]
        public string? Title { get; set; }

        [DisplayName("توضیحات ")]
        public string? Description { get; set; }

        [DisplayName("پروفایل ")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public IFormFile Image { get; set; }

        [DisplayName("سن ")]
        public string? Age { get; set; }

        [DisplayName("ایمیل ")]
        public string? Email { get; set; }

        [DisplayName("تلفن ")]
        public string? Phone { get; set; }
    }
}
