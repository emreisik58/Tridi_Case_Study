using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tridi_Case_Study.Controllers
{
    public class AccountController : Controller
    {
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (LoginUser(loginModel.Username, loginModel.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username)
            };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        private bool LoginUser(string username, string password)
        {
            if (username == "cagatay" && password == "123")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
