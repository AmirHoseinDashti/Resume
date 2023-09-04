using System.ComponentModel;

namespace Resume_Project.Models
{
    public class ArticleViewModel
    {
        public long Id { get; set; }

        [DisplayName("عنوان ")]
        public string? Name { get; set; }

        [DisplayName("توضیحات ")]
        public string? Description { get; set; }

        [DisplayName("تصویر ")]
        public string? Image { get; set; }
    }
}
