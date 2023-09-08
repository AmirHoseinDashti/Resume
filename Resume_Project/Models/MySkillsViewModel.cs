using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models;

public class MySkillsViewModel
{
    public long Id { get; set; }
    [DisplayName("عنوان ")]
    [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
    public string Title { get; set; }

    public bool Normal { get; set; }

    public bool Medium { get; set; }

    public bool Professional { get; set; }
}