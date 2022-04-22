using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Web.ViewComponents
{   
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public CategoryMenuViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}
