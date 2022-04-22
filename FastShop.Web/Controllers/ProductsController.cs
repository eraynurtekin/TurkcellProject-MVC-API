using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }
        public async Task<IActionResult> Index2()
        {
            return View();
        }
    }
}
