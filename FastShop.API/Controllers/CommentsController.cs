using FastShop.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await commentService.GetAllComments();
            return Ok(comments);
        }
        
       
    }
}
