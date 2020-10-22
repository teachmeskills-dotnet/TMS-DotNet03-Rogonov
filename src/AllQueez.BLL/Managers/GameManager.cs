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

        public async Task<IEnumerable<GameDto>> GetGameByUserIdAsync(string userId)
        {
            var gameDtos = new List<GameDto>();
            var games = await _repositoryGame
                .GetAll()
                .AsNoTracking()
                .Where(game => game.UserId == userId)
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
                    Title = game.Title,
                    Date = game.Date
                });
            }

            return gameDtos;
        }

        //public async Task<IEnumerable<GameDto>> GetGameByThemeIdAsync(int themeId)
        //{
        //    var games = await _repositoryGame
        //        .GetAll()
        //        .AsNoTracking()
        //        .Where(game => game.ThemeId == themeId)
        //        .ToListAsync();

        //    var gameDtos = new List<GameDto>();
        //    foreach (var game in games)
        //    {
        //        gameDtos.Add(new GameDto
        //        {
        //            Id = game.Id,
        //            UserId = game.UserId,
        //            ThemeId = game.ThemeId,
        //            Title = game.Title,
        //            Date = game.Date
        //        });
        //    }

        //    return gameDtos;
        //}
    }
}
