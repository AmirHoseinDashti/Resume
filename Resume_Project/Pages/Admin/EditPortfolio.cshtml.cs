using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Resume_Project.Data;
using Resume_Project.Extensions;
using Resume_Project.Models;
using Resume_Project.Statics;

namespace Resume_Project.Pages.Admin
{
    public class EditPortfolioModel : PageModel
    {
        private MyResumeContext _context;

        public EditPortfolioModel(MyResumeContext context)
        {
            _context = context;
        }

        [BindProperty] 
        public AddEditPortfolioViewModel Portfolio { get; set; }

        public void OnGet(long id)
        {

            var portfolio = _context.Portfolio.Where(p => p.Id == id)
                .Select(s => new AddEditPortfolioViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    WebsiteUrl = s.WebsiteUrl
                }).FirstOrDefault()!;

            Portfolio = portfolio;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var portfolio = _context.Portfolio.Find(Portfolio.Id);

            portfolio!.Name = Portfolio.Name;
            portfolio!.Description = Portfolio.Description;
            portfolio!.WebsiteUrl = Portfolio.WebsiteUrl;

            string filePath = PathTools.PortfolioImageServerPath;

            if (System.IO.File.Exists(filePath + portfolio!.Image))
            {
                System.IO.File.Delete(filePath + portfolio.Image);
            }

            portfolio.Image = Guid.NewGuid() + Path.GetExtension(Portfolio.Image!.FileName);
            _context.SaveChanges();
            if (Portfolio.Image?.Length > 0)
            {
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

            return RedirectToPage("Portfolio");
        }
    }
}
