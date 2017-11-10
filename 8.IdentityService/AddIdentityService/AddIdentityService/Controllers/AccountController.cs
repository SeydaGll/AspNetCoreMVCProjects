using AddIdentityService.Models;
using AddIdentityService.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddIdentityService.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<MyIdentityUser>    userManager;
        private readonly SignInManager<MyIdentityUser>  loginManager;
        private readonly RoleManager<MyIdentityRole>    roleManager;
        public AccountController(
            UserManager<MyIdentityUser> _userManager,
        SignInManager<MyIdentityUser>   _loginManager,
        RoleManager<MyIdentityRole>     _roleManager
            )
        {
            userManager = _userManager;
            loginManager = _loginManager;
            roleManager = _roleManager;

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //xss açıkları için önlem almış olursun
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)  // bana gelen modelin geçerli olup olmadığını kontrol et
            {
                MyIdentityUser user = new MyIdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    TCNO = model.TCNO
                };

                IdentityResult result = 
                await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync("NormalUser").Result)
                    {
                        MyIdentityRole role = new MyIdentityRole
                        {
                            Name = "NormalUser",
                            Description = "SiteUsers"
                        };

                        IdentityResult roleResult = await roleManager.CreateAsync(role);
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "role oluşturulurken hata meydana geldi");
                            return View(model)
                        }

                    }
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                    return RedirectToAction("login", "account");
                }
                
            }
            return View(model);
            

        }

        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = loginManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError("", "Invalid Login!");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            loginManager.SignOutAsync().Wait();
            return RedirectToAction("login", "Account");
        }
    }
}
