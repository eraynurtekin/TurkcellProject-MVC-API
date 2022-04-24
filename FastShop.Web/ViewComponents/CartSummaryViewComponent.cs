using Microsoft.AspNetCore.Mvc;

namespace FastShop.Web.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
