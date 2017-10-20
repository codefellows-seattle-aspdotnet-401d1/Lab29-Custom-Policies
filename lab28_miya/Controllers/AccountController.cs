using lab28_miya.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace lab28_miya.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = rvm.Email, Email = rvm.Email, FirstName = rvm.FirstName, LastName = rvm.LastName };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if(result.Succeeded)
                {
                    List<Claim> myClaims = new List<Claim>();

                    Claim claim1 = new Claim(ClaimTypes.Name, rvm.FirstName + " " + rvm.LastName, ClaimValueTypes.String);
                    myClaims.Add(claim1);

                    Claim claim2 = new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String);
                    myClaims.Add(claim2);

                    var addClaims = await _userManager.AddClaimsAsync(user, myClaims);

                    if (addClaims.Succeeded)
                    {
                        await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, true, lockoutOnFailure: false);

                        return RedirectToAction("Index", "Home");

                    }                                                       
                }
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        private IActionResult AccessDenied()
        {
            return View("Forbidden");
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return View();
        }
    }
}
