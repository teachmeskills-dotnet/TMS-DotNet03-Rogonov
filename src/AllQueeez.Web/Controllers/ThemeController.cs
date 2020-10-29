using AllQueez.BLL.Interfaces;
using AllQueez.BLL.Models;
using AllQueez.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllQueez.Web.Controllers
{
    [Authorize]
    public class ThemeController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IThemeManager _themeManager;

        public ThemeController(IAccountManager accountManager, IThemeManager themeManager)
        {
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
            _themeManager = themeManager ?? throw new System.ArgumentNullException(nameof(themeManager));
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var themeDtos = await _themeManager.GetThemeByUserIdAsync(userId);

            var themeViewModels = new List<ThemesViewModel>();
            foreach (var themeDto in themeDtos)
            {
                themeViewModels.Add(new ThemesViewModel
                {
                    Id = themeDto.Id,
                    Name = themeDto.Name
                });
            }

            return View(themeViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThemeActionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var themeDto = new ThemeDto
                {
                    UserId = userId,
                    Name = model.Name
                };

                await _themeManager.CreateAsync(themeDto);
                return RedirectToAction("Index", "Theme");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _themeManager.DeleteAsync(id, userId);
            return RedirectToAction("Index", "Theme");
        }
    }
}
