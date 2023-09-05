using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Models;

namespace Resume_Project.Pages.Admin
{
    public class AddPortfolioModel : PageModel
    {
        private MyResumeContext _context;

        public AddPortfolioModel(MyResumeContext context)
        {
            _context = context;
        }

        [BindProperty] 
        public AddEditPortfolioViewModel Portfolio { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var portfolio = new PortfolioViewModel()
            {
                Name = Portfolio.Name,
                Description = Portfolio.Description,
                WebsiteUrl = Portfolio.WebsiteUrl,
                Image = Portfolio.Image!.FileName
            };
            _context.Add(portfolio);
            _context.SaveChanges();

            if (Portfolio.Image?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "portfolio",
                    Portfolio.Image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Portfolio.Image.CopyTo(stream);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
