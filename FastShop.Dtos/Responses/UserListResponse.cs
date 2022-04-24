using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Dtos.Responses
{
    public class UserListResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Eposta { get; set; }
        public string Role { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}
