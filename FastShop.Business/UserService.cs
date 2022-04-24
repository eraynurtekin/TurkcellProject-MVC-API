using AutoMapper;
using FastShop.DataAccess.Repositories;
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

        public IList<UserListResponse> GetUsers()
        {
            var users = userRepository.GetAll();
            var userListResponse = mapper.Map<List<UserListResponse>>(users);
            return userListResponse;
        }

        public User ValidateUser(string userName, string password)
        {
           var user = userRepository.ValidateUser(userName, password);
           return user;
        }
    }
}
