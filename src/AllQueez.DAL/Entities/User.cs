using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AllQueez.DAL.Entities
{
    /// <summary>
    /// User by IdentityUser.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Navigation to Themes.
        /// </summary>
        public ICollection<Theme> Themes { get; set; }
    }
}
