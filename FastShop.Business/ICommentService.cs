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
        
       
    }
}
