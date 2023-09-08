using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models;

public class MyServicesViewModel
{
    public long Id { get; set; }

    [DisplayName("عنوان ")]
    public string? Title { get; set; }

    [DisplayName("تصویر ")]
    [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
    public string Image { get; set; }
}