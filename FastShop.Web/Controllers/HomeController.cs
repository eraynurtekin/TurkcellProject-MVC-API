using FastShop.Business;
using FastShop.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ICommentService commentService;

        public HomeController(IProductService productService,ICommentService commentService)
        {
            this.productService = productService;
            this.commentService = commentService;
        }

        public async Task<IActionResult> Index(int page=1 ,int? catId=0)
        {
            var productsFromService = await productService.GetProducts();
            var products = catId == 0 ? productsFromService.ToList() : productsFromService.Where(p => p.CategoryId == catId).ToList();
            var productsPerPage = 8;

            var paginatedPrdoucts = products.OrderBy(x => x.ProductId)
                                            .Skip((page - 1) * productsPerPage)
                                            .Take(productsPerPage);

            ViewBag.CurrentPage = page;
            ViewBag.Category = catId;

            ViewBag.TotalPages = Math.Ceiling((decimal)products.Count / productsPerPage);
            return View(paginatedPrdoucts);
        }
       
        [HttpGet]
        public IActionResult GetDetails(int id)
        {
            var product = productService.GetById(id);

            var comment = commentService.GetCommentCountByProduct(product.ProductId);
            ViewBag.CommentCount = comment;
            ViewBag.Id = id;
            return View(product);
        }
        [HttpGet]
        public PartialViewResult PartialAddComment(int id)
        {
            ViewBag.ID = id;
            return PartialView();
        }
        [HttpPost]
        public async Task<PartialViewResult> PartialAddComment(AddCommentRequest model)
        {

            model.CreatedDate = DateTime.Now;
            model.CommentStatus = true;
            model.ProductScore = 5;
            await commentService.AddComment(model);
            return PartialView();
        }

       
    }
}
