using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Extensions;
using Resume_Project.Models;
using Resume_Project.Statics;

namespace Resume_Project.Pages.Admin.Services
{
    public class EditModel : PageModel
    {
        private MyResumeContext _context;

        public EditModel(MyResumeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditServices Service { get; set; }

        public void OnGet(long id)
        {
            var service = _context.Services.Where(p => p.Id == id)
                .Select(s => new AddEditServices()
                {
                    Id = s.Id,
                    Title = s.Title,
                }).FirstOrDefault()!;

            Service = service;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var service = _context.Services.Find(Service.Id);

            service!.Title = Service.Title;

            string filePath = PathTools.ServiceImageServerPath;

            if (System.IO.File.Exists(filePath + service!.Image))
            {
                System.IO.File.Delete(filePath + service.Image);
            }

            service.Image = Guid.NewGuid() + Path.GetExtension(Service.Image!.FileName);
            _context.SaveChanges();

            if (Service.Image?.Length > 0)
            {
                var validFormats = new List<string>()
                {
                    ".png",
                    ".jpg",
                    ".jpeg"
                };
                var result = Service.Image.UploadFile(service.Image, PathTools.ServiceImageServerPath, validFormats);

                if (!result)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToPage("Index");
        }
    }
 }
