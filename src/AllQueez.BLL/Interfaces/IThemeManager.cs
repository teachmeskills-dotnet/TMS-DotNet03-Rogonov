using AllQueez.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllQueez.BLL.Interfaces
{
    /// <summary>
    /// Theme manager interface.
    /// </summary>
    public interface IThemeManager
    {
        /// <summary>
        /// Create theme by user identifier.
        /// </summary>
        /// <param name="themeDto">Theme data transfer object.</param>
        Task CreateAsync(ThemeDto themeDto);

        /// <summary>
        /// Get theme by user identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Theme.</returns>
        Task<IEnumerable<ThemeDto>> GetThemeByUserIdAsync(string userId);

        //Task UpdateAsync(int id, string userId);

        /// <summary>
        /// Delete theme by user and theme identifiers.
        /// </summary>
        /// <param name="id">Theme identifier.</param>
        /// <param name="userId">User identifier..</param>
        Task DeleteAsync(int id, string userId);
    }
}
