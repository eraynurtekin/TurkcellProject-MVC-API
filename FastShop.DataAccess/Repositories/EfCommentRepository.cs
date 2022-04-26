using FastShop.DataAccess.Data;
using FastShop.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.DataAccess.Repositories
{
    public class EfCommentRepository : ICommentRepository
    {
        private FastShopDbContext context;

        public EfCommentRepository(FastShopDbContext context)
        {
            this.context = context;
        }

        public Task Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllComment()
        {
            return context.Comments.ToList();
        }

        public async Task<IList<Comment>> GetAllEntites()
        {
            return await context.Comments.ToListAsync();
        }

        public List<Comment> GetCommentByProductId(int id)
        {
            var comments = context.Comments.Where(c => c.ProductId == id).ToList();
            return comments;
        }

        public int GetCommentCounts(int id)
        {
            var commentCount = context.Comments.Where(c=>c.ProductId == id).Count();
            return commentCount;
        }

        public Task<Comment> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
