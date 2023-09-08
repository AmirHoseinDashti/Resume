using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models;

public class MySkillsViewModel
{
    public long Id { get; set; }
    [DisplayName("عنوان ")]
    [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
    public string Title { get; set; }

    [DisplayName("سطح مبتدی ")]
    public bool Normal { get; set; }

    [DisplayName("سطح متوسط ")]
    public bool Medium { get; set; }

    [DisplayName("سطح پیشرفته ")]
    public bool Professional { get; set; }
}