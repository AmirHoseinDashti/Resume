using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Resume_Project.Data;
using Resume_Project.Models;

namespace Resume_Project.Pages.Admin.Skills
{
    public class DetailsModel : PageModel
    {
        private readonly Resume_Project.Data.MyResumeContext _context;

        public DetailsModel(Resume_Project.Data.MyResumeContext context)
        {
            _context = context;
        }

        public MySkillsViewModel MySkillsViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MySkillsViewModel = await _context.Skills.FirstOrDefaultAsync(m => m.Id == id);

            if (MySkillsViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
