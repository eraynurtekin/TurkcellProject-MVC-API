using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Dtos.Requests
{
    public class AddUserRequest
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz.")]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; }
        public string Eposta { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
