using AllQueez.BLL.Interfaces;
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
        private readonly IRoundQuestionManager _themeManager;

        public ThemeController(IAccountManager accountManager, IRoundQuestionManager themeManager)
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
    }
}
