using FastShop.Business;
using FastShop.Dtos.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FastShop.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;


        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await commentService.GetAllComments();

            return View(comments);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await commentService.DeleteComment(id);
            return RedirectToAction("GetAllComments", "Comment");

        }

    

    }



}
