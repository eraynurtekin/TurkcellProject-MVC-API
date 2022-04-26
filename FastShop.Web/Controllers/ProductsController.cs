using FastShop.Business;
using FastShop.Dtos.Requests;
using FastShop.Dtos.Responses;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{

    [Authorize(Roles = "Admin")]
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

        [HttpGet]
        public async Task<IActionResult> UpdateProducts(int id)
        {
            if(await productService.IsExist(id))
            {
                ProductListResponse response = await productService.GetProductById(id);

                ViewBag.Categories = GetCategoriesForDropDown();
                return View(response);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProducts(UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProduct(request);
                RedirectToAction("Index", "Products");
            }
            else
            {
                return BadRequest();
            }
            ViewBag.Categories = GetCategoriesForDropDown();
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.IsExist(id))
            {
                var product = await productService.GetProductById(id);
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteOk(int id)
        {
            await productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
