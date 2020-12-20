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
    public class RoundController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IRoundManager _roundManager;
        private readonly IGameManager _gameManager;
        private readonly IRoundQuestionManager _roundQuestionManager;

        public RoundController(IAccountManager accountManager,
            IRoundManager roundManager,
            IGameManager gameManager,
            IRoundQuestionManager roundQuestionManager)
        {
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
            _roundManager = roundManager ?? throw new System.ArgumentNullException(nameof(roundManager));
            _gameManager = gameManager ?? throw new System.ArgumentNullException(nameof(gameManager));
            _roundQuestionManager = roundQuestionManager ?? throw new System.ArgumentNullException(nameof(roundQuestionManager));
        }

        public async Task<IActionResult> Index(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var gameId = await _gameManager.GetGameAsync(id, userId);
            var roundDtos = await _roundManager.GetRoundByGameIdAsync(gameId.Id);

            var roundViewModels = new List<RoundsViewModel>();
            foreach (var roundDto in roundDtos)
            {
                roundViewModels.Add(new RoundsViewModel
                {
                    Id = roundDto.Id,
                    Title = roundDto.Title
                });
            }

            return View(roundViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, GameContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var gameId = await _gameManager.GetGameAsync(id, userId);
                var roundDto = new RoundDto
                {
                    GameId = gameId.Id,
                    Title = model.RoundTitle,
                };

                await _roundManager.CreateAsync(roundDto);
                return Redirect($"/game/gameContent/{id}");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoundQuestion([FromBody] IEnumerable<GameContentViewModel> model)
        {
            if (ModelState.IsValid)
            {
                var roundQuestionDto = new RoundQuestionDto
                {
                    //RoundId = model.RoundId,
                    //QuestionId = model.QuestionId
                };

                await _roundQuestionManager.AddQuestionAsync(roundQuestionDto);
                return View();
            }

            return View();
        }

        //        public async Task<IActionResult> Delete(int id)
        //        {
        //            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
        //            await _roundManager.DeleteAsync(id, userId);
        //            return RedirectToAction("Index", "Round");
        //        }
    }
}
