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
        /// Create game by user identifier.
        /// </summary>
        /// <param name="gameDto">Game data transfer object.</param>
        Task CreateAsync(GameDto gameDto);

        /// <summary>
        /// Get game by user identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>List of Game data transfer objects.</returns>
        Task<IEnumerable<GameDto>> GetGameByUserIdAsync(string userId);

        /// <summary>
        /// Get game by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Game data transfer object.</returns>
        Task<GameDto> GetGameAsync(int id, string userId);

        /// <summary>
        /// Get game idenifier by user identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Game identifier.</returns>
        Task<int> GetGameIdByUserIdAsync(string userId);

        /// <summary>
        /// Delete game by user and game identifiers.
        /// </summary>
        /// <param name="id">Game identifier.</param>
        /// <param name="userId">User identifier.</param>
        Task DeleteAsync(int id, string userId);
    }
}