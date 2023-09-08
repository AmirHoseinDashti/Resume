using Microsoft.AspNetCore.Mvc;
using Resume_Project.Data;

namespace Resume_Project.ViewComponents
{
    public class MySkillViewComponent: ViewComponent
    {
        private MyResumeContext _context;

        public MySkillViewComponent(MyResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var skill = _context.Skills;

            return View("MySkill", skill);
        }
    }
}
