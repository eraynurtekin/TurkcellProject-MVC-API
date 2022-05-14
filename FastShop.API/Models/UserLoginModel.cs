using System.ComponentModel.DataAnnotations;

namespace FastShop.API.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string Password { get; set; }
    }
}
