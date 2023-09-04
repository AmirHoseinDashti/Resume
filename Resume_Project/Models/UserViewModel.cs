namespace Resume_Project.Models
{
    public class UserViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
