using AllQueez.BLL.Interfaces;
using AllQueez.BLL.Models;
using AllQueez.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace AllQueez.BLL.Managers
{
    /// <inheritdoc cref="IRoundQuestionManager"/>
    public class RoundQuestionManager : IRoundQuestionManager
    {
        private readonly IRepository<RoundQuestion> _repositoryRoundQuestion;

        public RoundQuestionManager(IRepository<RoundQuestion> repositoryRoundQuestion)
        {
            _repositoryRoundQuestion = repositoryRoundQuestion ?? throw new ArgumentNullException(nameof(repositoryRoundQuestion));
        }

        public async Task AddQuestionAsync(RoundQuestionDto roundQuestionDto)
        {
            var roundQuestion = new RoundQuestion
            {
                Id = roundQuestionDto.Id,
                RoundId = roundQuestionDto.RoundId,
                QuestionId = roundQuestionDto.QuestionId
            };

            await _repositoryRoundQuestion.CreateAsync(roundQuestion);
            await _repositoryRoundQuestion.SaveChangesAsync();
        }
    }
}