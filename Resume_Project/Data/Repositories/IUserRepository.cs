using Resume_Project.Models;

namespace Resume_Project.Data.Repositories
{
    public interface IUserRepository
    {
        UserViewModel GetUserForLogin(string email ,  string password );
    }

    public class UserRepository : IUserRepository
    {
        private MyResumeContext _context;

        public UserRepository(MyResumeContext context)
        {
            _context = context;
        }


        public UserViewModel GetUserForLogin(string email, string password)
        {
            return _context.User.SingleOrDefault(u => u.Email == email && u.Password == password)!;
        }
    }
}
