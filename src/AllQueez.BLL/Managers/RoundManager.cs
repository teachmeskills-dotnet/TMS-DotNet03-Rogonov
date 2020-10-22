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
    /// <inheritdoc cref="IRoundManager"/>
    public class RoundManager : IRoundManager
    {
        private readonly IRepository<Round> _repositoryRound;

        public RoundManager(IRepository<Round> repositoryRound)
        {
            _repositoryRound = repositoryRound ?? throw new ArgumentNullException(nameof(repositoryRound));
        }

        public async Task<IEnumerable<RoundDto>> GetRoundByUserIdAsync(string userId)
        {
            var roundDtos = new List<RoundDto>();
            var rounds = await _repositoryRound
                .GetAll()
                .AsNoTracking()
                .Where(round => round.UserId == userId)
                .ToListAsync();

            if (!rounds.Any())
            {
                return roundDtos;
            }

            foreach (var round in rounds)
            {
                roundDtos.Add(new RoundDto
                {
                    Id = round.Id,
                    UserId = round.UserId,
                    GameId = round.GameId,
                    Title = round.Title,
                    Type = round.Type
                });
            }

            return roundDtos;
        }
    }
}