using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{

    public class AccountController : Controller

    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(userName:model.Email, model.Password,isPersistent:model.RememberMe,lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect email or password");
                }
                
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrarse(RegistrarseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Data");
                return View(model);
            }
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Registrarse()
        {
            return View(new RegistrarseViewModel());
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }
    }
}