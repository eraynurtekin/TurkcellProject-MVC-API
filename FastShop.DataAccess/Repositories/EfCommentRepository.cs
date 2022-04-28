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

        public async Task Add(Comment entity)
        {
            await context.Comments.AddAsync(entity);
            await context.SaveChangesAsync();        
        }

        public int AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public int CountComment()
        {
            return context.Comments.Where(c =>c.CommentStatus == true).Count();
        }

        public async Task Delete(int id)
        {
            var comment = await context.Comments.FirstOrDefaultAsync(c =>c.CommentID == id);
            comment.CommentStatus = false;
            await context.SaveChangesAsync();   
        }

        public List<Comment> GetAllComment()
        {
            return context.Comments.ToList();
        }

        public async Task<IList<Comment>> GetAllEntites()
        {
            return await context.Comments.Where(c=>c.CommentStatus == true).ToListAsync();
        }

        public List<Comment> GetCommentByProductId(int id)
        {
            var comments = context.Comments.Where(c => c.ProductId == id && c.CommentStatus == true).ToList();
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

        public async Task<bool> IsExists(int id)
        {
            return await context.Comments.AnyAsync(c => c.CommentID == id);
        }

        public Task Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
