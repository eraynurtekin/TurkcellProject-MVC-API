using FastShop.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastShop.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        public DashboardController(IProductService productService,IUserService userService,ICommentService commentService)
        {
            this.productService = productService;
            this.userService = userService;
            this.commentService = commentService;
        }

        public IActionResult Index()
        {
            var totalOfProduct = productService.TotalOfProduct();
            ViewBag.TotalOfProduct = totalOfProduct;

            var totalOfUser = userService.TotalOfUser();
            ViewBag.TotalOfUser = totalOfUser;

            var totalOfComment = commentService.TotalOfComment();
            ViewBag.TotalOfComment = totalOfComment;

            return View();
        }
    }
}
