using AllQueez.BLL.Interfaces;
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

        public RoundController(IAccountManager accountManager, IRoundManager roundManager)
        {
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
            _roundManager = roundManager ?? throw new System.ArgumentNullException(nameof(roundManager));
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
    }
}
