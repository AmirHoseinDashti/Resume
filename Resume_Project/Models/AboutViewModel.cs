using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resume_Project.Models
{
    public class AboutViewModel
    {
        public long Id { get; set; }

        [DisplayName("عنوان ")]
        public string? Title { get; set; }

        [DisplayName("توضیحات ")]
        public string? Description { get; set; }

        [DisplayName("پروفایل ")]
        public string? Image { get; set; }

        [DisplayName("سن ")]
        public string? Age { get; set; }

        [DisplayName("ایمیل ")]
        public string? Email { get; set; }

        [DisplayName("تلفن ")]
        public string? Phone { get; set; }

        public AboutViewModel(long id, string? title, string? description, string? image, string? age, string? email, string? phone)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Age = age;
            Email = email;
            Phone = phone;
        }
    }
}
