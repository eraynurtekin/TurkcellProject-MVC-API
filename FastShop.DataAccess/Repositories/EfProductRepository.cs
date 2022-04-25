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
            entity.IsActive = true;
            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            product.IsActive = false;   
            await context.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAllEntites()
        {
           
            return await context.Products.Where(x=>x.IsActive == true).ToListAsync();
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await context.Products.Where(x => x.IsActive == true).FirstOrDefaultAsync(x => x.ProductId == id);   
        }

        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await context.Products.AnyAsync(p=>p.ProductId == id);
        }

        public async Task Update(Product entity)
        {
            context.Products.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
