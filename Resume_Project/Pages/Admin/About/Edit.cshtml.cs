using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resume_Project.Data;
using Resume_Project.Extensions;
using Resume_Project.Models;
using Resume_Project.Statics;

namespace Resume_Project.Pages.Admin.About
{
    public class EditModel : PageModel
    {
        private MyResumeContext _context;

        public EditModel(MyResumeContext context)
        {
            _context = context;
        }

        [BindProperty] public EditAboutViewModel About { get; set; }

        public void OnGet(long id)
        {
            var about = _context.About.Where(p => p.Id == id)
                .Select(s => new EditAboutViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Age = s.Age,
                    Email = s.Email,
                    Phone = s.Phone
                }).FirstOrDefault()!;

            About = about;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var about = _context.About.Find(About.Id);

            about!.Title = About.Title;
            about!.Description = About.Description;
            about!.Email = About.Email;
            about!.Phone = About.Phone;
            about!.Age = About.Age;
            string filePath = PathTools.AboutImageServerPath;

            if (System.IO.File.Exists(filePath + about!.Image))
            {
                System.IO.File.Delete(filePath + about.Image);
            }
            about.Image = Guid.NewGuid() + Path.GetExtension(About.Image!.FileName);

            _context.SaveChanges();

            if (About.Image?.Length > 0)
            {
                var validFormats = new List<string>()
                {
                    ".png",
                    ".jpg",
                    ".jpeg"
                };
                var result = About.Image.UploadFile(about.Image, PathTools.AboutImageServerPath, validFormats);

                if (!result)
                {
                    return RedirectToAction("/About/Edit");
                }
            }

            return RedirectToPage("Index");
        }
    }
}
