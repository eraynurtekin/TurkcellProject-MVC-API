using AutoMapper;
using FastShop.DataAccess.Repositories;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private IMapper mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public User AddUser(AddUserRequest request)
        {
            var user = mapper.Map<User>(request);
            userRepository.Add(user);
            return user;
        }

        public async Task<IList<UserListResponse>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllEntites();
            var userListResponse = mapper.Map<List<UserListResponse>>(users);
            return userListResponse;
        }

        public UserListResponse GetUserByUserName(string username)
        {
            User user = userRepository.GetByUserName(username);
            var userListResponse = mapper.Map<UserListResponse>(user);
            return userListResponse;
        }

        public IList<UserListResponse> GetUsers()
        {
            var users = userRepository.GetAll();
            var userListResponse = mapper.Map<List<UserListResponse>>(users);
            return userListResponse;
        }

        public int TotalOfUser()
        {
            return userRepository.UserCount();
        }

        public User ValidateUser(string userName, string password)
        {
           var user = userRepository.ValidateUser(userName, password);
           return user;
        }
    }
}
