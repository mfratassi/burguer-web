using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LanchesWeb.ViewModels;

namespace LanchesWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //GET
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            IdentityUser user = await _userManager.FindByNameAsync(loginViewModel.Username);

            if (user != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult signInResult =
                    await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    return RedirectToAction(loginViewModel.ReturnUrl);
                }
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = registerViewModel.Username,
                };

                Microsoft.AspNetCore.Identity.IdentityResult identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (identityResult.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ViewBag.Errors = identityResult.Errors.ToList();
                    return View();
                }
            }
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}