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
    /// <inheritdoc cref="IGameManager"/>
    public class GameManager : IGameManager
    {
        private readonly IRepository<Game> _repositoryGame;

        public GameManager(IRepository<Game> repositoryGame)
        {
            _repositoryGame = repositoryGame ?? throw new ArgumentNullException(nameof(repositoryGame));
        }

        public async Task CreateAsync(GameDto gameDto)
        {
            var game = new Game
            {
                Id = gameDto.Id,
                UserId = gameDto.UserId,
                ThemeId = gameDto.ThemeId,
                Title = gameDto.Title,
                Description = gameDto.Description,
                Date = gameDto.Date
            };

            await _repositoryGame.CreateAsync(game);
            await _repositoryGame.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameDto>> GetGameByUserIdAsync(string userId)
        {
            var gameDtos = new List<GameDto>();
            var games = await _repositoryGame
                .GetAll()
                .AsNoTracking()
                .Where(game => game.UserId == userId)
                .Include(game => game.Theme)
                .ToListAsync();

            if (!games.Any())
            {
                return gameDtos;
            }

            foreach (var game in games)
            {
                gameDtos.Add(new GameDto
                {
                    Id = game.Id,
                    UserId = game.UserId,
                    ThemeId = game.ThemeId,
                    ThemeName = game.Theme.Name,
                    Title = game.Title,
                    Description = game.Description,
                    Date = game.Date
                });
            }

            return gameDtos;
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var game = await _repositoryGame.GetEntityAsync(game => game.Id == id && game.UserId == userId);
            // TODO: checks and confirmation

            if (game is null)
            {
                return;
            }
            _repositoryGame.Delete(game);
            await _repositoryGame.SaveChangesAsync();
        }
    }
}
