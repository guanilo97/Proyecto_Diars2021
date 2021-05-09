using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proyecto_diars.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_diars.Controllers
{
    public class AuthController : Controller
    {
        private AppCartaContext context;
        private IConfiguration configuration;
        public AuthController(AppCartaContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = context.Usuarios
               .FirstOrDefault(o => o.Username == username && o.Password == CreateHash(password));
            //  var user = context.Usuarios.FirstOrDefault(o => o.Username == usernme && o.Password == CreateHash(password));
            if (user == null)
            {
                TempData["AuthMessaje"] = "Usuario o password incorrectos";
                return RedirectToAction("Login");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),

            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Logaut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public string Create(string password)
        {
            return CreateHash(password);
        }
        private string CreateHash(string input)
        {
            input += configuration.GetValue<string>("Key");
            var sha = SHA512.Create();
            var bytes = Encoding.Default.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
