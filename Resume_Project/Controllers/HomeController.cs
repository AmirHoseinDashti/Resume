using Microsoft.AspNetCore.Mvc;
using Resume_Project.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Resume_Project.Data;
using Microsoft.Win32;

namespace Resume_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyResumeContext _context;

        public HomeController(ILogger<HomeController> logger, MyResumeContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("Contact")]
        public IActionResult Contact(ContactViewModel contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ContactViewModel contacts = new ContactViewModel()
            {
                Name = contact.Name,
                Email = contact.Email,
                Message = contact.Message
            };
            _context.Add(contacts);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}