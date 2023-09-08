using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Models;
using Resume_Project.Statics;

namespace Resume_Project.Pages.Admin
{
    public class DeletePortfolioModel : PageModel
    {
        private MyResumeContext _context;

        public DeletePortfolioModel(MyResumeContext context)
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
            var portfolio = _context.Portfolio.Find(Portfolio.Id);
            _context.Portfolio.Remove(portfolio!);

            string filePath = PathTools.PortfolioImageServerPath;

            if (System.IO.File.Exists(filePath + portfolio!.Image))
            {
                System.IO.File.Delete(filePath + portfolio.Image);
            }

            _context.SaveChanges();
            return RedirectToPage("Portfolio");
        }
    }
}
