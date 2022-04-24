using FastShop.Dtos.Responses;
using FastShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Business
{
    public interface IUserService 
    {
        IList<UserListResponse> GetUsers();
        User ValidateUser(string userName, string password);
    }
}
