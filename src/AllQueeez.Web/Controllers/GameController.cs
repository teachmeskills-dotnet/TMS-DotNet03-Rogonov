using AllQueez.BLL.Interfaces;
using AllQueez.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AllQueez.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IGameManager _gameManager;

        public GameController(IAccountManager accountManager, IGameManager gameManager)
        {
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
            _gameManager = gameManager ?? throw new System.ArgumentNullException(nameof(gameManager));
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
    }
}
