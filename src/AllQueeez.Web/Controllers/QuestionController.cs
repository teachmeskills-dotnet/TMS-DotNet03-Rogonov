using AllQueez.BLL.Interfaces;
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
    }
}
