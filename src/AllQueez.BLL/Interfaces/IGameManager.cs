using AllQueez.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllQueez.BLL.Interfaces
{
    /// <summary>
    /// Game manager interface.
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Get game by user identifier.
        /// </summary>
        /// <param name="id">User identifier.</param>
        /// <returns>Game.</returns>
        Task<IEnumerable<GameDto>> GetGameByUserIdAsync(string userId);

        ///// <summary>
        ///// Get game by theme identifier.
        ///// </summary>
        ///// <param name="id">Theme identifier.</param>
        ///// <returns>Game.</returns>
        //Task<IEnumerable<GameDto>> GetGameByThemeIdAsync(int themeId);
    }
}
