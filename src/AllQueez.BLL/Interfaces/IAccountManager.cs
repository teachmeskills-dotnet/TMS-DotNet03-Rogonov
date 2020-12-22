using AllQueez.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AllQueez.BLL.Interfaces
{
    /// <summary>
    /// Account manager interface.
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Sign up.
        /// </summary>
        /// <param name="user-Dto">User data transfer object.</param>
        /// <param name="password">Password.</param>
        /// <returns>Identity result.</returns>
        Task<IdentityResult> SignUpAsync(UserDto userDto);

        /// <summary>
        /// Get user identifier by name.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <returns>Identifier (GUID).</returns>
        Task<string> GetUserIdByNameAsync(string name);
    }
}