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
        /// Create round by user identifier.
        /// </summary>
        /// <param name="roundDto">Round data transfer object.</param>
        Task CreateAsync(RoundDto roundDto);

        /// <summary>
        /// Get round by user identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Round.</returns>
        Task<IEnumerable<RoundDto>> GetRoundByUserIdAsync(string userId);

        /// <summary>
        /// Delete round by user and round identifiers.
        /// </summary>
        /// <param name="id">Round identifier.</param>
        /// <param name="userId">User identifier..</param>
        Task DeleteAsync(int id, string userId);
    }
}
