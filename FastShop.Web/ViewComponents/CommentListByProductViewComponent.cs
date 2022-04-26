using FastShop.Business;
using Microsoft.AspNetCore.Mvc;

namespace FastShop.Web.ViewComponents
{
    public class CommentListByProductViewComponent :ViewComponent
    {
        private readonly ICommentService commentService;

        public CommentListByProductViewComponent(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var comments = commentService.GetComments(id);
            return View(comments);
        }
    }
}
