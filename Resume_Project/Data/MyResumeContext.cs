using Microsoft.EntityFrameworkCore;
using Resume_Project.Models;

namespace Resume_Project.Data
{
    public class MyResumeContext:DbContext
    {
        public MyResumeContext(DbContextOptions<MyResumeContext> options):base(options)
        {
            
        }

        public DbSet<AboutViewModel> About { get; set; }
        public DbSet<ArticleViewModel> Article { get; set; }
        public DbSet<MyServicesViewModel> Services { get; set; }
        public DbSet<MySkillsViewModel> Skills { get; set; }
        public DbSet<PortfolioViewModel> Portfolio { get; set; }
        public DbSet<UserViewModel> User { get; set; }
        public DbSet<ContactViewModel> Contact { get; set; }
    }
}
