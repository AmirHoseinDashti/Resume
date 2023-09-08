using Microsoft.AspNetCore.Mvc;
using Resume_Project.Data;

namespace Resume_Project.ViewComponents
{
    public class MyServiceViewComponent : ViewComponent
    {
        private MyResumeContext _context;

        public MyServiceViewComponent(MyResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var service = _context.Services;

            return View("MyService", service);
        }
    }
}
