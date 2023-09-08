using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Models;

namespace Resume_Project.Pages.Admin.Requests
{
    public class IndexModel : PageModel
    {
        private MyResumeContext _context;

        public IndexModel(MyResumeContext context)
        {
            _context = context;
        }

        public IEnumerable<ContactViewModel> Contact { get; set; }
        public void OnGet()
        {
            Contact = _context.Contact;
        }
    }
}
