﻿using FastShop.Business;
using FastShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FastShop.Web.Extensions;

namespace FastShop.Web.Controllers
{
    public class CartController : Controller
    {
        private IProductService productService;

        public CartController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var cartCollection = getCollectionFromSession();
            return View(cartCollection);
        }

        public async Task<IActionResult> Add(int id)
        {
            if (await productService.IsExist(id))
            {
                var product = await productService.GetProductById(id);
                CartCollection cartCollection = getCollectionFromSession();
                cartCollection.Add(new CartItem { Product = product, Quantity = 1 });
                saveToSession(cartCollection);
                return Json($"{product.ProductName} Sepete Eklendi");
            }


            return NotFound();
        }

        private void saveToSession(CartCollection cartCollection)
        {
          HttpContext.Session.SetJson("sepetim",cartCollection);
        }

        private CartCollection getCollectionFromSession()
        {
            CartCollection cartCollection = null;

            //if(HttpContext.Session.GetString("sepetim") == null)
            //{
            //    cartCollection = new CartCollection();
            //}
            //else
            //{
            //    var cartCollectionJson = HttpContext.Session.GetString("sepetim");
            //    cartCollection = JsonConvert.DeserializeObject<CartCollection>(cartCollectionJson);
            //}
            cartCollection = HttpContext.Session.GetJson<CartCollection>("sepetim") ?? new CartCollection();
            return cartCollection;
        }
    }
}
