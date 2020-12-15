using AllQueez.BLL.Interfaces;
using AllQueez.BLL.Models;
using AllQueez.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllQueez.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IGameManager _gameManager;
        private readonly IThemeManager _themeManager;
        private readonly IQuestionManager _questionManager;

        public GameController(IAccountManager accountManager, IGameManager gameManager, IThemeManager themeManager, IQuestionManager questionManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
            _themeManager = themeManager ?? throw new ArgumentNullException(nameof(themeManager));
            _questionManager = questionManager ?? throw new ArgumentNullException(nameof(questionManager));
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
                    ThemeName = gameDto.ThemeName,
                    Title = gameDto.Title,
                    Description = gameDto.Description,
                    Date = gameDto.Date
                });
            }

            return View(gameViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var themes = (await _themeManager.GetThemeByUserIdAsync(userId)).Select(c => new { c.Id, c.Name }).ToList();
            themes.Insert(0, new { Id = 0, Name = "Theme name" });
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
                    Description = model.Description,
                    Date = model.Date.HasValue ? model.Date : DateTime.Now
                };

                await _gameManager.CreateAsync(gameDto);
                return RedirectToAction("Index", "Game");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GameContent(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var gameDto = await _gameManager.GetGameAsync(id, userId);

            var gameViewModel = new GameContentViewModel
            {
                Id = gameDto.Id,
                ThemeId = gameDto.ThemeId,
                ThemeName = gameDto.ThemeName,
                Title = gameDto.Title,
                Description = gameDto.Description,
                Date = gameDto.Date
            };

            var questions = (await _questionManager.GetQuestionByUserIdAsync(userId)).Select(q => new { q.Id, q.Description }).ToList();
            questions.Insert(0, new { Id = 0, Description = "Question description" });
            ViewBag.Questions = new SelectList(questions, "Id", "Description");

            return View(gameViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _gameManager.DeleteAsync(id, userId);
            return RedirectToAction("Index", "Game");
        }
    }
}
