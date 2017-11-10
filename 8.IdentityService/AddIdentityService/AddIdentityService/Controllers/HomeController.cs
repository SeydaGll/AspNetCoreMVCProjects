using AddIdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddIdentityService.Controllers
{
    
    public class HomeController:Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;

        public HomeController(UserManager<MyIdentityUser> _userManager)
        {
            userManager = _userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            MyIdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.Message = $"Welcome {user.UserName}";
            if (userManager.IsInRoleAsync(user,"NormalUser").Result)
            {
                ViewBag.RoleMessage = "You are a Normal User";
            }
            return View();
        }
    }
}
