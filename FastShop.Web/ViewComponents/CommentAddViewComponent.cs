using FastShop.Business;
using FastShop.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FastShop.Web.ViewComponents
{
    public class CommentAddViewComponent : ViewComponent
    {
        private readonly ICommentService commentService;

        public CommentAddViewComponent(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IViewComponentResult Invoke(AddCommentRequest model)
        {
            commentService.AddComment(model);
            return View();
        }
    }
}
