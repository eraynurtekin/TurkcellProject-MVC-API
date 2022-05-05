using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FastShop.Web.ViewComponents
{
    public class ProductListLastAddViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public ProductListLastAddViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var products = productService.GetAllProductsOrderBy().Take(5);
            return View(products);

        }
    }
}
