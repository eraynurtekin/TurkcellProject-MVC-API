using FastShop.Business;
using FastShop.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(model.UserName, model.Password);
                if (user != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Eposta),
                        new Claim(ClaimTypes.Role, user.Role),
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                   
                    await HttpContext.SignInAsync(claimsPrincipal);

                    

                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("login", "Kullanıcı adı veya şifre hatalı");

            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
