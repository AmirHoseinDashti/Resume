using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Models;
using Resume_Project.Statics;

namespace Resume_Project.Pages.Admin.Services
{
    public class DeleteModel : PageModel
    {
        private MyResumeContext _context;

        public DeleteModel(MyResumeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditServices Services { get; set; }

        public void OnGet(long id)
        {
            var service = _context.Services.Where(p => p.Id == id)
                .Select(s => new AddEditServices()
                {
                    Id = s.Id,
                    Title = s.Title
                }).FirstOrDefault()!;

            Services = service;
        }

        public IActionResult OnPost()
        {
            var service = _context.Services.Find(Services.Id);
            _context.Services.Remove(service!);

            string filePath = PathTools.ServiceImageServerPath;

            if (System.IO.File.Exists(filePath + service!.Image))
            {
                System.IO.File.Delete(filePath + service.Image);
            }

            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
