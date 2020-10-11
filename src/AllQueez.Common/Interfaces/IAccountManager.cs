using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AllQueez.Common.Interfaces
{
    /// <summary>
    /// Account manager interface.
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Registration.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <returns>Identity result.</returns>
        Task<IdentityResult> RegisterAsync(string email, string username, string password);
    }
}
