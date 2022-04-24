using FastShop.Business;
using FastShop.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> selectedItems = GetCategoriesForDropDown();
            ViewBag.Categories = selectedItems;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest model)
        {
            if (ModelState.IsValid)
            {
                await productService.AddProduct(model);
                return RedirectToAction("Index","Products");
            }
            
            return View();
        }

        private List<SelectListItem> GetCategoriesForDropDown()
        {
            var selectedItems = new List<SelectListItem>();
            categoryService.GetCategories()
                           .ToList()
                           .ForEach(category => selectedItems.Add(
                               new SelectListItem
                               {
                                   Text = category.CategoryName,
                                   Value = category.CategoryId.ToString()
                               })
            );
            return selectedItems;
        }
    }
}
