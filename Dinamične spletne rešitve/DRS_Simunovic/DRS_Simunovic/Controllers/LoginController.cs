using DRS_Simunovic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;
//using Microsoft.AspNet.Identity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = login.Email, Email = login.Email};
                UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(AtletikaContext.Instance));

                var res = await _userManager.CreateAsync(user, login.Password);
                if (res.Succeeded)
                {
                    
                }
            }
            return View();
        }

        
    }
}
