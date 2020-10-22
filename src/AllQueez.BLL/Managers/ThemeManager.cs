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
    }
}
