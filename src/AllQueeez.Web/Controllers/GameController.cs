using AllQueez.BLL.Interfaces;
using AllQueez.BLL.Models;
using AllQueez.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AllQueez.DAL.Context;
using AllQueez.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using AllQueez.BLL.Managers;

namespace AllQueez.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IGameManager _gameManager;
        private readonly IThemeManager _themeManager;

        public GameController(IAccountManager accountManager, IGameManager gameManager, IThemeManager themeManager)
        {
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
            _gameManager = gameManager ?? throw new System.ArgumentNullException(nameof(gameManager));
            _themeManager = themeManager ?? throw new System.ArgumentNullException(nameof(themeManager));
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var gameDtos = await _gameManager.GetGameByUserIdAsync(userId);

            var gameViewModels = new List<GamesViewModel>();
            foreach (var gameDto in gameDtos)
            {
                gameViewModels.Add(new GamesViewModel
                {
                    Id = gameDto.Id,
                    ThemeId = gameDto.ThemeId,
                    Title = gameDto.Title,
                    Date = gameDto.Date
                });
            }

            return View(gameViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var themes = (await _themeManager.GetThemeByUserIdAsync(userId)).Select(c => new { c.Id, c.Name}).ToList();
            themes.Insert(0, new { Id = 0, Name = "Select Theme or Add new one" });
            ViewBag.Themes = new SelectList(themes, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameActionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var gameDto = new GameDto
                {
                    UserId = userId,
                    ThemeId = model.ThemeId,
                    Title = model.Title,
                    Date = model.Date
                };

                await _gameManager.CreateAsync(gameDto);
                return RedirectToAction("Index", "Game");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _gameManager.DeleteAsync(id, userId);
            return RedirectToAction("Index", "Game");
        }
    }
}
