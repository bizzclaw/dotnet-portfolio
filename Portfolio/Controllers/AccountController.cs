using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Portfolio.Models;
using System.Threading.Tasks;
using Portfolio.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers
{
	public class AccountController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;


		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
            int count = await _db.Users.CountAsync();
            return View(count);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
            int count = await _db.Users.CountAsync();

            if (count >= 1)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {

                Microsoft.AspNetCore.Identity.SignInResult logIn = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

		public async Task<IActionResult> LogOff()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}