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
    /// <inheritdoc cref="IThemeManager"/>
    public class ThemeManager : IThemeManager
    {
        private readonly IRepository<Theme> _repositoryTheme;

        public ThemeManager(IRepository<Theme> repositoryTheme)
        {
            _repositoryTheme = repositoryTheme ?? throw new ArgumentNullException(nameof(repositoryTheme));
        }

        public async Task CreateAsync(ThemeDto themeDto)
        {
            var theme = new Theme
            {
                Id = themeDto.Id,
                UserId = themeDto.UserId,
                Name = themeDto.Name
            };

            await _repositoryTheme.CreateAsync(theme);
            await _repositoryTheme.SaveChangesAsync();
        }

        public async Task<IEnumerable<ThemeDto>> GetThemeByUserIdAsync(string userId)
        {
            var themeDtos = new List<ThemeDto>();
            var themes = await _repositoryTheme
                .GetAll()
                .AsNoTracking()
                .Where(theme => theme.UserId == userId)
                .ToListAsync();

            if (!themes.Any())
            {
                return themeDtos;
            }

            foreach (var theme in themes)
            {
                themeDtos.Add(new ThemeDto
                {
                    Id = theme.Id,
                    UserId = theme.UserId,
                    Name = theme.Name
                });
            }

            return themeDtos;
        }

        //public async Task UpdateAsync(int id, string userId)
        //{
        //    var theme = await _repositoryTheme.GetEntityAsync(theme => theme.Id == id && theme.UserId == userId);

        //    if (theme is null)
        //    {
        //        return;
        //    }
        //    _repositoryTheme.Update(theme);
        //    await _repositoryTheme.SaveChangesAsync();
        //}

        public async Task DeleteAsync(int id, string userId)
        {
            var theme = await _repositoryTheme.GetEntityAsync(theme => theme.Id == id && theme.UserId == userId);
            // TODO: checks and confirmation

            if (theme is null)
            {
                return;
            }
            _repositoryTheme.Delete(theme);
            await _repositoryTheme.SaveChangesAsync();
        }
    }
}