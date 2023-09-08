using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Extensions;
using Resume_Project.Models;
using Resume_Project.Statics;

namespace Resume_Project.Pages.Admin.Services
{
    public class CreateModel : PageModel
    {
        private MyResumeContext _context;

        public CreateModel(MyResumeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditServices Services { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var services = new MyServicesViewModel()
            {
                Title = Services.Title,
                Image = Guid.NewGuid() + Path.GetExtension(Services.Image!.FileName)
            };
            _context.Add(services);
            _context.SaveChanges();

            if (Services.Image?.Length > 0)
            {
                //var fileName = Guid.NewGuid() + Path.GetExtension(Portfolio.Image.FileName);
                var validFormats = new List<string>()
                {
                    ".png",
                    ".jpg",
                    ".jpeg"
                };
                var result = Services.Image.UploadFile(services.Image, PathTools.ServiceImageServerPath, validFormats);

                if (!result)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
