using FastShop.DataAccess.Repositories;
using FastShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.DataAccess
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetCommentByProductId(int id);
        List<Comment> GetAllComment();
        int GetCommentCounts(int id);
    }
}
