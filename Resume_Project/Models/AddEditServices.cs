using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models
{
    public class AddEditServices
    {
        public long Id { get; set; }

        [DisplayName("عنوان ")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public string? Title { get; set; }

        [DisplayName("تصویر ")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public IFormFile Image { get; set; }
    }
}
