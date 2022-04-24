using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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

        public async Task<IActionResult> Index(int page=1 ,int? catId=0)
        {
            var productsFromService = await productService.GetProducts();
            var products = catId == 0 ? productsFromService.ToList() : productsFromService.Where(p => p.CategoryId == catId).ToList();
            var productsPerPage = 6;

            var paginatedPrdoucts = products.OrderBy(x => x.ProductId)
                                            .Skip((page - 1) * productsPerPage)
                                            .Take(productsPerPage);

            ViewBag.CurrentPage = page;
            ViewBag.Category = catId;

            ViewBag.TotalPages = Math.Ceiling((decimal)products.Count / productsPerPage);
            return View(paginatedPrdoucts);
        }
       
    }
}
