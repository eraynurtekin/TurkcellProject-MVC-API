using FastShop.API.Extensions;
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
            logger.LogInformation($"Bu action, {DateTime.Now} anında çalıştı ve bütün ürünleri getirdi.");
            var products = await productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        [IsExist]
        public async Task<IActionResult> GetProductsById(int id)
        {
            
            var product = await productService.GetProductById(id);
            logger.LogInformation($"Bu action, {DateTime.Now} anında çalıştı ve {product.ProductName} adlı ürünü getirdi.");
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

                return Ok(CommonExtensions.AddSuccessfulMessage(request));
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
                var text = $" {DateTime.Now} tarihinde {id}'li ürün güncellendi!";
                logger.LogInformation(text);
                await WriteToFileAsync(text);
                return Ok(CommonExtensions.UpdateSuccessfulMessage(request,id));
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Editor")]
        [IsExist]
        public async Task<IActionResult> Delete(int id)
        {
            var user = User.Identity.Name;
            await productService.DeleteProduct(id);
            var text = $" {DateTime.Now} tarihinde {id}'li ürün {user} kişisi tarafından silindi!";
            logger.LogInformation(text);
            await WriteToFileAsync(text);
            return Ok(CommonExtensions.ErrorDeleteMessage(id));
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
