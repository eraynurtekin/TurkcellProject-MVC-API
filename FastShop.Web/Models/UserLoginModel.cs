using System.ComponentModel.DataAnnotations;

namespace FastShop.Web.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage="Lütfen Kullanıcı Adını Giriniz.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Lütfen Şifrenizi Giriniz.")]
        public string Password { get; set; }
    }
}
