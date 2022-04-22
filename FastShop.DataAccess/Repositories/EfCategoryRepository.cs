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
    public class EfCategoryRepository : ICategoryRepository
    {
        private FastShopDbContext context;

        public EfCategoryRepository(FastShopDbContext context)
        {
            this.context = context;
        }

        public Task Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public async Task<IList<Category>> GetAllEntites()
        {
            return await context.Categories.ToListAsync();
        }

        public Task<Category> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
