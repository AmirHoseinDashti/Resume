using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Models;

namespace Resume_Project.Pages.Admin
{
    public class PortfolioModel : PageModel
    {
        private MyResumeContext _context;

        public PortfolioModel(MyResumeContext context)
        {
            _context = context;
        }

        public IEnumerable<PortfolioViewModel> Portfolio { get; set; }

        public void OnGet()
        {
            Portfolio = _context.Portfolio;
        }
    }
}
