using BookStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(Login login)
        {
            if (!ModelState.IsValid) 
            {
                return View(login);
            }
            var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name, login.Username!),
                        new Claim(ClaimTypes.Role, "user"),
                        new Claim("FavoriteDrink", "Tea")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());
            return View();
        }
    }
}
