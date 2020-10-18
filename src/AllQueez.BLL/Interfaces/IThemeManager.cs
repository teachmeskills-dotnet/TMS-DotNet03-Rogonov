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
        /// Get theme by identifier.
        /// </summary>
        /// <param name="id">User identifier.</param>
        /// <returns>Theme.</returns>
        Task<IEnumerable<ThemeDto>> GetThemeByUserIdAsync(string userid);
    }
}
