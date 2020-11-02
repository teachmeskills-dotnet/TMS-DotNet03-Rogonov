using AllQueez.BLL.Interfaces;
using AllQueez.BLL.Models;
using AllQueez.DAL.Context;
using AllQueez.DAL.Entities;
using AllQueez.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllQueez.Web.Controllers
{
    [Authorize]
    public class RoundController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IRoundManager _roundManager;
        private readonly AllQueezContext _allQueezContext;

        public RoundController(IAccountManager accountManager, IRoundManager roundManager, AllQueezContext allQueezContext)
        {
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
            _roundManager = roundManager ?? throw new System.ArgumentNullException(nameof(roundManager));
            _allQueezContext = allQueezContext ?? throw new System.ArgumentNullException(nameof(allQueezContext));        
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var roundDtos = await _roundManager.GetRoundByUserIdAsync(userId);

            var roundViewModels = new List<RoundsViewModel>();
            foreach (var roundDto in roundDtos)
            {
                roundViewModels.Add(new RoundsViewModel
                {
                    Id = roundDto.Id,
                    GameId = roundDto.GameId,
                    Title = roundDto.Title,
                    Type = roundDto.Type
                });
            }

            return View(roundViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoundActionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var roundDto = new RoundDto
                {
                    UserId = userId,
                    GameId = model.GameId,
                    Title = model.Title,
                    Type = model.Type
                };

                await _roundManager.CreateAsync(roundDto);
                return RedirectToAction("Index", "Round");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _roundManager.DeleteAsync(id, userId);
            return RedirectToAction("Index", "Round");
        }
    }
}
