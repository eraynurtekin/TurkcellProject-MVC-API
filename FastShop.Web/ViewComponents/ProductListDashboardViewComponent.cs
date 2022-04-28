using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FastShop.Web.ViewComponents
{
    public class ProductListDashboardViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public ProductListDashboardViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        
        public IViewComponentResult Invoke()
        {
            var products = productService.GetAllProductsOrderBy().Take(10);
            return View(products);
        }
    }
}
