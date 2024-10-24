using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using AuthSystem.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthSystem.Controllers {

    public class AccountController : Controller {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {

            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) {

            if (ModelState.IsValid) {

                var user = new ApplicationUser {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) {

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Profile", "Home");
                }

                foreach (var error in result.Errors) {

                    System.Console.WriteLine(error.Description);

                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model) {

            if (ModelState.IsValid) {
                
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false
                );

                if (result.Succeeded) {

                    return RedirectToAction("Profile", "Home");
                }

                ModelState.AddModelError(string.Empty, "در ورود با مشکل مواجه شدید");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}