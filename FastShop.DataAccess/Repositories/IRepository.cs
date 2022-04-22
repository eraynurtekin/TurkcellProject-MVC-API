using FastShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<IList<T>> GetAllEntites();
        Task<T> GetEntityById(int id);
        Task Delete(int id);
        Task Add(T entity);
        Task Update(T entity);
    }
}
