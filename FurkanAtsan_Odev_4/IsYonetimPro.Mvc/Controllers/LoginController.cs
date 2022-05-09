using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Entities.Dtos;
using IsYonetimPro.Services.Abstract;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Mvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IsYonetimSistemiDBContext _ısYonetimSistemiDBContext;

        public LoginController(IsYonetimSistemiDBContext ısYonetimSistemiDBContext)
        {
            _ısYonetimSistemiDBContext = ısYonetimSistemiDBContext;
        }

       [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(EmployeeDto emp)
        {
            var info = _ısYonetimSistemiDBContext.Employees.FirstOrDefault(x => x.EmployeeEmail == emp.Employee.EmployeeEmail && x.EmployeePassword == emp.Employee.EmployeePassword);
            if (info!=null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();//bütün ayarları bu yapıcak
                var tokenKey = Encoding.ASCII.GetBytes("bu benim secret key alanim alanim alanim");//signaturedeki  key alanı
                 //claims içinde ad,id,role,email gibi bilgiler saklanabilir.
                 //hangi bilgilerin kullanıcı login olduğu sürece saklanmasını istiyorsak claimste tutabiliriz.
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email,emp.Employee.EmployeeEmail));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,emp.Employee.EmployeeRoleId.ToString()));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,"1"));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "2"));
                
                //claimsIdentity.AddClaim(new Claim(ClaimTypes.Name,emp.Employee.EmployeeName));
                //claimsIdentity.AddClaim(new Claim(ClaimTypes.Surname,emp.Employee.EmployeeSurname));

                //Token yaratılırken gereken parametreleri belirliyoruz/claimsType/expireDate
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject=claimsIdentity,
                    Expires=DateTime.Now.AddDays(1),

                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256)//token keyi HmacSha256 ile hasledik.Şifreleme yöntemini belirledik.
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);//token handlerdan bir token uret tokendescriptor bilgilerini kullan
                string tokenCookie=tokenHandler.WriteToken(token);//tokeni yaz.
                HttpContext.Response.Cookies.Append("EmployeeToken", tokenCookie);
                return RedirectToAction("Index", "Home");

                
            }
            return View();
        }
        [HttpGet]
        public IActionResult LogOut() 
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "login");
        }
    }
}
