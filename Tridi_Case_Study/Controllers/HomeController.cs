using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tridi_Case_Study.Infrastructure;
using Tridi_Case_Study.Models;

namespace Tridi_Case_Study.Controllers
{
    public class HomeController : Controller
    {

        private IQueryProviderRepo _QueryProviderRepo;

        public HomeController(IQueryProviderRepo QueryProviderRepo)
        {
            _QueryProviderRepo = QueryProviderRepo;
        }

        [Authorize]
        public IActionResult Index()
        {

           string name = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();
            User Contact = _QueryProviderRepo.getByUserName(name);
            List<User> users = _QueryProviderRepo.getByListUser().Where(u => u.userName.ToString().ToLower() != name.ToLower()).ToList();
            ViewBag.Contact = Contact;
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public async Task<List<User>> GetListUsers()
        {

            List<User> users = new List<User>();

            try
            {

                var username = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                       .Select(c => c.Value).SingleOrDefault();

                users = _QueryProviderRepo.getByListUser().Where(u => u.userName != username).ToList() ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return users;
        }

    }
}
