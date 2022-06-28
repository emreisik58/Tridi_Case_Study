using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Tridi_Case_Study.Infrastructure;

namespace Tridi_Case_Study.Controllers
{
    public class AccountController : Controller
    {
        private IQueryProviderRepo _QueryProviderRepo;

        public AccountController(IQueryProviderRepo QueryProviderRepo)
        {
            _QueryProviderRepo = QueryProviderRepo;
        }
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["isLogin"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {

            ViewData["isLogin"] = true;
            if (_QueryProviderRepo.getUserControl(loginModel.Username, loginModel.Password))
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
            else
                ViewData["isLogin"] = false;

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
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
