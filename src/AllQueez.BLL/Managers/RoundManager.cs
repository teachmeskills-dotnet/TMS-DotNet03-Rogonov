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

        public async Task CreateAsync(RoundDto roundDto)
        {
            var round = new Round
            {
                Id = roundDto.Id,
                GameId = roundDto.GameId,
                Title = roundDto.Title,
            };

            await _repositoryRound.CreateAsync(round);
            await _repositoryRound.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoundDto>> GetRoundByGameIdAsync(int gameId)
        {
            var roundDtos = new List<RoundDto>();
            var rounds = await _repositoryRound
                .GetAll()
                .AsNoTracking()
                .Where(round => round.GameId == gameId)
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
                    GameId = round.GameId,
                    Title = round.Title,
                });
            }

            return roundDtos;
        }

        public async Task DeleteAsync(int id, int gameId)
        {
            var round = await _repositoryRound.GetEntityAsync(round => round.Id == id && round.GameId == gameId);
            // TODO: checks and confirmation

            if (round is null)
            {
                return;
            }
            _repositoryRound.Delete(round);
            await _repositoryRound.SaveChangesAsync();
        }
    }
}