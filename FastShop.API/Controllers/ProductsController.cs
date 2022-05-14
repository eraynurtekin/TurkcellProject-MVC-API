using FastShop.API.Filters;
using FastShop.Business;
using FastShop.Dtos.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FastShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            logger.LogInformation($"Bu action, {DateTime.Now} anında çalıştı.");
            var products = await productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        [IsExist]
        public async Task<IActionResult> GetProductsById(int id)
        {
            var product = await productService.GetProductById(id);
            return Ok(product);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            var user = User.Identity.Name;

            if (ModelState.IsValid)
            {
                await productService.AddProduct(request);
                var text = $"{request.ProductName}-{request.UnitPrice}₺ fiyatlı olan ürün, {DateTime.Now} tarihinde {user} kişisi tarafından eklendi!";
                logger.LogInformation(text);            
                await WriteToFileAsync(text);

                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        [IsExist]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProduct(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        [IsExist]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProduct(id);
            return Ok();
        }

        public static async Task WriteToFileAsync(string text)
        {
            string pathToFile = @"C:\Users\HP\Desktop\TurkcellLogs\Logs.txt";

            using (StreamWriter writeFile = new StreamWriter(pathToFile,true))
            {
                await writeFile.WriteLineAsync(text);
                writeFile.Close();
            };
        }


    }
}
