using AllQueez.BLL.Interfaces;
using AllQueez.BLL.Models;
using AllQueez.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllQueez.BLL.Managers
{
    /// <inheritdoc cref="IQuestionManager"/>
    public class QuestionManager : IQuestionManager
    {
        private readonly IRepository<Question> _repositoryQuestion;

        public QuestionManager(IRepository<Question> repositoryQuestion)
        {
            _repositoryQuestion = repositoryQuestion ?? throw new ArgumentNullException(nameof(repositoryQuestion));
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionByUserIdAsync(string userId)
        {
            var questionDtos = new List<QuestionDto>();
            var questions = await _repositoryQuestion
                .GetAll()
                .AsNoTracking()
                .Where(question => question.UserId == userId)
                .ToListAsync();

            if (!questions.Any())
            {
                return questionDtos;
            }

            foreach (var question in questions)
            {
                questionDtos.Add(new QuestionDto
                {
                    Id = question.Id,
                    UserId = question.UserId,
                    Title = question.Title,
                    Description = question.Description,
                    Comment = question.Comment,
                    File = question.File,
                    Path = question.Path,
                    Answer = question.Answer
                });
            }

            return questionDtos;
        }
    }
}
