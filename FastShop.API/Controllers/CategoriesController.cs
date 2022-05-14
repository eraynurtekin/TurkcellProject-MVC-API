using FastShop.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace FastShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMemoryCache memoryCache;

        public CategoriesController(ICategoryService categoryService, IMemoryCache memoryCache)
        {
            this.categoryService = categoryService;
            this.memoryCache = memoryCache;
        }

        [HttpGet(Name = "GetCategories")]
        [ResponseCache(Duration = 60, VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetAllCategory();

            return Ok(new { categories, time = DateTime.Now });
        }
        

    }
}
