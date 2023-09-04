using Microsoft.AspNetCore.Mvc;
using Resume_Project.Data;

namespace Resume_Project.ViewComponents
{
    public class AboutViewComponent:ViewComponent
    {

        private MyResumeContext _context;

        public AboutViewComponent(MyResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var about = _context.About;

            return View("About" , about);
        }
    }
}
