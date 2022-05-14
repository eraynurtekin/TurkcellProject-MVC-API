using FastShop.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet(Name ="GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetAllCategory();
            return Ok(categories);
        }

    }
}
