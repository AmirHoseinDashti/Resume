using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume_Project.Data;
using Resume_Project.Models;

namespace Resume_Project.ViewComponents
{
    public class PortfolioViewComponent : ViewComponent
    {
        private MyResumeContext _context;

        public PortfolioViewComponent(MyResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var portfolio = _context.Portfolio;

            return View("Portfolio" , portfolio);
        }
    }
}
