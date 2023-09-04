using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Models;

namespace Resume_Project.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MyResumeContext _context;

        public IndexModel(MyResumeContext context)
        {
            _context = context;
        }

        public IEnumerable<AboutViewModel> About { get; set; }
        public void OnGet()
        {
            About = _context.About;
        }
    }
}
