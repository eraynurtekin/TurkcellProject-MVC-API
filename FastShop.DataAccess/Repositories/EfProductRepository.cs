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
    public class EfProductRepository : IProductRepository
    {
        private FastShopDbContext context;

        public EfProductRepository(FastShopDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Product entity)
        {
            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAllEntites()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task Update(Product entity)
        {
            context.Products.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
