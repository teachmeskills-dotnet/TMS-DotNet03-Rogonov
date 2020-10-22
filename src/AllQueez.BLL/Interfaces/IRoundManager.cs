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
        /// Get round by user identifier.
        /// </summary>
        /// <param name="id">User identifier.</param>
        /// <returns>Round.</returns>
        Task<IEnumerable<RoundDto>> GetRoundByUserIdAsync(string userId);
    }
}
