using Microsoft.AspNetCore.Mvc;

namespace FastShop.Web.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
