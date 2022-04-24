using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}
