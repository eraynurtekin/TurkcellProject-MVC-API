using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }
       
    }
}
