using FastShop.API.Models;
using FastShop.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            var user = userService.ValidateUser(model.UserName,model.Password);
            if(user != null)
            {
                //1. adım Claim bilgileri:
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.FullName),
                    new Claim(ClaimTypes.Role,user.Role),
                };
                //2. adım JWT Tokenda oluşturduğumuz algoritma kısmı. Gizli cümlenin üretilmesi.
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Sisteme giriş yapacağınız key alanıdır."));
                var credential = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                //3.Adım Token'ın özelliklerini tanımla. Token ' ın üretildiği yer.
                var token = new JwtSecurityToken(
                    issuer:"fastShop.com.tr",
                    audience:"fastShop.com.tr",
                    claims:claims,
                    notBefore:DateTime.Now,
                    expires:DateTime.Now.AddMinutes(15),
                    signingCredentials:credential
                    );
                //4. adım ürettiğimiz token'i istemciye ileteceğiz
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest(new { message = "Hatalı Kullanıcı Adı Ya da Şifre girdiniz." });
        }
    }
}
