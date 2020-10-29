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
    public class QuestionController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IQuestionManager _questionManager;

        public QuestionController(IAccountManager accountManager, IQuestionManager questionManager)
        {
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
            _questionManager = questionManager ?? throw new System.ArgumentNullException(nameof(questionManager));
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var questionDtos = await _questionManager.GetQuestionByUserIdAsync(userId);

            var questionViewModels = new List<QuestionsViewModel>();
            foreach (var questionDto in questionDtos)
            {
                questionViewModels.Add(new QuestionsViewModel
                {
                    Id = questionDto.Id,
                    Title = questionDto.Title,
                    Description = questionDto.Description,
                    Comment = questionDto.Comment,
                    File = questionDto.File,
                    Path = questionDto.Path,
                    Answer = questionDto.Answer
                });
            }

            return View(questionViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionActionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var questionDto = new QuestionDto
                {
                    UserId = userId,
                    Title = model.Title,
                    Description = model.Description,
                    Comment = model.Comment,
                    File = model.File,
                    Path = model.Path,
                    Answer = model.Answer
                };

                await _questionManager.CreateAsync(questionDto);
                return RedirectToAction("Index", "Question");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _questionManager.DeleteAsync(id, userId);
            return RedirectToAction("Index", "Question");
        }
    }
}
