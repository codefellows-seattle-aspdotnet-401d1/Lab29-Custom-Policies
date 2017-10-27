using System.Security.Claims;
using lab29_brian.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace lab29_brian.Controllers
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
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel rvm, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = rvm.UserName,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToLocal(returnUrl);
                }
            }
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.UserName, lvm.Password, lvm.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult AdminReg(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminReg(RegistrationViewModel rvm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = rvm.UserName,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName
                };
                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    await _CheckForBrian(user);
                    var addAdmin = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String));

                    if (addAdmin.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToLocal(returnUrl);
                    }
                }
            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private async Task _CheckForBrian(ApplicationUser user)
        {
            //Also Briannas
            if (user.FirstName.Contains("Brian"))
            {
               await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Brian Only", ClaimValueTypes.String));
            }
            
        }
    }
}
