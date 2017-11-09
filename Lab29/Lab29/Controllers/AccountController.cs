using Lab29.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lab29.Controllers
{
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            string error = "you are wrong";
            ModelState.AddModelError("", error);
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = rvm.LastName, Email = rvm.Email, FirstName = rvm.FirstName, LastName = rvm.LastName, Birthday = rvm.Birthday };
                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {

                    
                    //Create a list where my claims will be added to
                    List<Claim> myClaims = new List<Claim>();

                    // claim for the User's role
                    Claim claim1 = new Claim(ClaimTypes.Name, rvm.FirstName + " " + rvm.LastName, ClaimValueTypes.String);
                    myClaims.Add(claim1);

                    //Claim for the user's name
                    Claim claim2 = new Claim(ClaimTypes.Role, "Member", ClaimValueTypes.String);
                    myClaims.Add(claim2);

                    Claim dateOfBirth = new Claim(ClaimTypes.DateOfBirth, rvm.Birthday.Date.ToString(), ClaimValueTypes.Date);

                    myClaims.Add(dateOfBirth);

                    var userIdentity = new ClaimsIdentity("Registration");
                    userIdentity.AddClaims(myClaims);

                    var userPrinciple = new ClaimsPrincipal(userIdentity);

                    User.AddIdentity(userIdentity);

                    var addClaims = await _userManager.AddClaimsAsync(user, myClaims);

                    return RedirectToAction("Index", "Home");

                }


            }
            return View();
        }
        [HttpGet]
        public IActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminRegister(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = rvm.LastName, Email = rvm.Email, FirstName = rvm.FirstName, LastName = rvm.LastName, Birthday = rvm.Birthday };
                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    List<Claim> adminClaims = new List<Claim>();

                    Claim adminClaim = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String);
                    adminClaims.Add(adminClaim);

                    var userIdentity = new ClaimsIdentity("Registration");
                    userIdentity.AddClaims(adminClaims);

                    var userPrinciple = new ClaimsPrincipal(userIdentity);

                    User.AddIdentity(userIdentity);

                    var addClaims = await _userManager.AddClaimsAsync(user, adminClaims);

                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }



        public IActionResult AccessDenied()
        {
            return View("Forbidden");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}