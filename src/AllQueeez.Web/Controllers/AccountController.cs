using AllQueez.Common.Interfaces;
using AllQueez.DAL.Entities;
using AllQueez.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AllQueez.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IAccountManager accountManager, SignInManager<User> signInManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(accountManager));
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: refactor
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Username,
                };

                var result = await _accountManager.RegisterAsync(model.Email, model.Username, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
