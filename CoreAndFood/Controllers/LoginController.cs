using CoreAndFood.DATA.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreAndFood.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            var datavalue = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);

            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, p.Username),
                     new Claim(ClaimTypes.Role,"A")

                };

                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(useridentity), authProperties);

                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
