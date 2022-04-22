using FastShop.DataAccess.Repositories;
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

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User ValidateUser(string userName, string password)
        {
           var user = userRepository.ValidateUser(userName, password);
           return user;
        }
    }
}
