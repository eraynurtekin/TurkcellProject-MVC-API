using FastShop.Business;
using FastShop.Dtos.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Editör,User")]
        public IActionResult Index()
        {
            var users = userService.GetUsers();
            return View(users);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(AddUserRequest model)
        {
            if (ModelState.IsValid)
            {
                model.Role = "Member";
                userService.AddUser(model);
                return RedirectToAction("Index","Home");
            }

            return View();
        }
    }
}
