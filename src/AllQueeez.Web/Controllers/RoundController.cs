using AllQueez.BLL.Interfaces;
using AllQueez.BLL.Models;
using AllQueez.DAL.Context;
using AllQueez.DAL.Entities;
using AllQueez.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllQueez.Web.Controllers
{
    [Authorize]
    public class RoundController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IRoundManager _roundManager;
        private readonly IGameManager _gameManager;
        private readonly IQuestionManager _questionManager;

        public RoundController(IAccountManager accountManager, IRoundManager roundManager, IGameManager gameManager, IQuestionManager questionManager)
        {
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
            _roundManager = roundManager ?? throw new System.ArgumentNullException(nameof(roundManager));
            _gameManager = gameManager ?? throw new System.ArgumentNullException(nameof(gameManager));
            _questionManager = questionManager ?? throw new System.ArgumentNullException(nameof(questionManager));
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

        [HttpGet]
        public async Task<IActionResult> AddRound()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var questions = (await _questionManager.GetQuestionByUserIdAsync(userId)).Select(q => new { q.Id, q.Description }).ToList();
            questions.Insert(0, new { Id = 0, Description = "Question description" });
            ViewBag.Questions = new SelectList(questions, "Id", "Description");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, RoundActionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var gameId = await _gameManager.GetGameAsync(id, userId);
                var roundDto = new RoundDto
                {
                    GameId = gameId.Id,
                    QuestionId = model.QuestionId,
                    Title = model.Title,
                };

                await _roundManager.CreateAsync(roundDto);
                return Redirect($"/game/gameContent/{id}");
            }

            return View(model);
        }

        //        public async Task<IActionResult> Delete(int id)
        //        {
        //            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
        //            await _roundManager.DeleteAsync(id, userId);
        //            return RedirectToAction("Index", "Round");
        //        }
    }
}
