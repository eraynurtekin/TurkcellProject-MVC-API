using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace FastShop.Web.ViewComponents
{
    public class UserAboutOnNavbarViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public UserAboutOnNavbarViewComponent(IUserService userService)
        {
            this.userService = userService;
        }
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.UserName = userName;
            
            var userInformation = userService.GetUserByUserName(userName);
            var role = userInformation.Role;
            var fullName = userInformation.FullName;
            ViewBag.Role = role;
            ViewBag.FullName = fullName;

            return View();
        }
    }
}
