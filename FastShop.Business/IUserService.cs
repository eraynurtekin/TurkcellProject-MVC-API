using FastShop.Dtos.Requests;
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
        Task<IList<UserListResponse>> GetAllUsersAsync();
        IList<UserListResponse> GetUsers();
        User ValidateUser(string userName, string password);
        User AddUser(AddUserRequest request);
        int TotalOfUser();
        UserListResponse GetUserByUserName(string username);
    }
}
