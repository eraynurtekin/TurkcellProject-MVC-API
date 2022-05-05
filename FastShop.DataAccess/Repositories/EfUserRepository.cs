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
    public class EfUserRepository : IUserRepository
    {
        private FastShopDbContext context;

        public EfUserRepository(FastShopDbContext context)
        {
            this.context = context;
        }

        public async Task Add(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public IList<User> GetAll()
        {
            return context.Users.ToList();
        }

        public async Task<IList<User>> GetAllEntites()
        {
            return await context.Users.ToListAsync();
        }

        public User GetByUserName(string username)
        {
            return context.Users.FirstOrDefault(x => x.UserName == username);   
        }

        public async Task<User> GetEntityById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(User entity)
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }

        public int UserCount()
        {
            return context.Users.Where(u=>u.IsActive==true).Count();   
        }

        public User ValidateUser(string username, string password)
        {
           var user =  context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
           return user;
        }
    }
}
