using FastShop.Web.Extensions;
using FastShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastShop.Web.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var collection = HttpContext.Session.GetJson<CartCollection>("sepetim");
            return View(collection);
        }
    }
}
