
using FastShop.Dtos.Requests;
using FastShop.Dtos.Responses;
using FastShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Business
{
    public interface ICommentService
    {
        IList<CommentListResponse> GetComments(int id);
        int GetCommentCountByProduct(int id);
        Task AddComment(AddCommentRequest request);
        Task<IList<CommentListResponse>> GetAllComments();
        Task DeleteComment(int id);
        Task<bool> IsExist(int id);
        int TotalOfComment();
        

    }
}
