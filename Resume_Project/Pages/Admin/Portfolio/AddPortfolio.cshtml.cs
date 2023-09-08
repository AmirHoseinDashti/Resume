using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Extensions;
using Resume_Project.Models;
using Resume_Project.Statics;

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

            var portfolio  = new PortfolioViewModel()
            {
                Name = Portfolio.Name,
                Description = Portfolio.Description,
                WebsiteUrl = Portfolio.WebsiteUrl,
                Image = Guid.NewGuid() + Path.GetExtension(Portfolio.Image!.FileName)
            };
            _context.Add(portfolio);
            _context.SaveChanges();

            if (Portfolio.Image?.Length > 0)
            {
                //var fileName = Guid.NewGuid() + Path.GetExtension(Portfolio.Image.FileName);
                var validFormats = new List<string>()
                {
                    ".png",
                    ".jpg",
                    ".jpeg"
                };
                var result = Portfolio.Image.UploadFile(portfolio.Image, PathTools.PortfolioImageServerPath, validFormats);

                if (!result)
                {
                    return RedirectToAction("AddPortfolio");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
