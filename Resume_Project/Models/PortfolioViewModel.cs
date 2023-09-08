using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models;

public class PortfolioViewModel
{
    public long Id { get; set; }

    [DisplayName("عنوان ")]
    public string? Name { get; set; }

    [DisplayName("توضیحات ")]
    public string? Description { get; set; }

    [DisplayName("تصویر ")]
    [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
    public string Image { get; set; }

    [DisplayName("لینک نمونه کار ")]
    public string? WebsiteUrl { get; set; }

}