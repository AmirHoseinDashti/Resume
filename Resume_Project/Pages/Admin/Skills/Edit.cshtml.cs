using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resume_Project.Data;
using Resume_Project.Models;

namespace Resume_Project.Pages.Admin.Skills
{
    public class EditModel : PageModel
    {
        private readonly Resume_Project.Data.MyResumeContext _context;

        public EditModel(Resume_Project.Data.MyResumeContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MySkillsViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MySkillsViewModelExists(MySkillsViewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MySkillsViewModelExists(long id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
