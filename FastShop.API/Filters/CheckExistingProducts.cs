using FastShop.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace FastShop.API.Filters
{
    public class CheckExistingProducts : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public CheckExistingProducts(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idExist = context.ActionArguments.ContainsKey("id");
            if (!idExist)
            {
                context.Result = new BadRequestObjectResult(new { message = $"id parametresi yok!" });

            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                if (await productService.IsExist(id))
                {
                    //İşlemi yapmaya devam edicek.
                    await next.Invoke();
                }
                context.Result = new BadRequestObjectResult(new { message = $"{id} id li ürün bulunamadı." });

            }


        }
    }
}
