using System.ComponentModel;

namespace Resume_Project.Models
{
    public class AddEditPortfolioViewModel
    {
        public long Id { get; set; }

        [DisplayName("عنوان ")]
        public string? Name { get; set; }

        [DisplayName("توضیحات ")]
        public string? Description { get; set; }

        [DisplayName("تصویر ")]
        public IFormFile? Image { get; set; }

        [DisplayName("لینک نمونه کار ")]
        public string? WebsiteUrl { get; set; }
    }
}
