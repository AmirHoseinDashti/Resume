using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Resume_Project.Data;
using Resume_Project.Data.Repositories;
using Resume_Project.Models;
using System.Security.Claims;

namespace Resume_Project.Controllers
{
    public class AccountController : Controller
    {
 
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userRepository.GetUserForLogin(login.Email.ToLower() , login.Password);

            if(user == null)
            {
                ModelState.AddModelError("Email" , "اطلاعات وارد شده صحیح نمی باشد");

                return View(login);
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("IsAdmin", user.IsAdmin.ToString())

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(principal);

            return Redirect("/");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
