using AllQueez.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllQueez.BLL.Interfaces
{
    /// <summary>
    /// Round manager interface.
    /// </summary>
    public interface IRoundManager
    {
        /// <summary>
        /// Create round by game identifier.
        /// </summary>
        /// <param name="roundDto">Round data transfer object.</param>
        Task CreateAsync(RoundDto roundDto);

        /// <summary>
        /// Get round by game identifier.
        /// </summary>
        /// <param name="userId">Game identifier.</param>
        /// <returns>Round.</returns>
        Task<IEnumerable<RoundDto>> GetRoundByGameIdAsync(int gameId);

        /// <summary>
        /// Delete round by game and round identifiers.
        /// </summary>
        /// <param name="id">Round identifier.</param>
        /// <param name="userId">Game identifier.</param>
        Task DeleteAsync(int id, int gameId);
    }
}