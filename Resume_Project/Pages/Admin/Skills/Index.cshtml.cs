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
    public class IndexModel : PageModel
    {
        private readonly Resume_Project.Data.MyResumeContext _context;

        public IndexModel(Resume_Project.Data.MyResumeContext context)
        {
            _context = context;
        }

        public IList<MySkillsViewModel> MySkillsViewModel { get;set; }

        public async Task OnGetAsync()
        {
            MySkillsViewModel = await _context.Skills.ToListAsync();
        }
    }
}
