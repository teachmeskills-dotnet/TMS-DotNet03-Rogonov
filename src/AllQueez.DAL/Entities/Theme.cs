using AllQueez.DAL.Interfaces;
using System.Collections.Generic;

namespace AllQueez.DAL.Entities
{
    /// <summary>
    /// Themes.
    /// </summary>
    public class Theme : IHasDbIdentity, IHasUserIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string UserId { get; set; }

        /// <summary>
        /// Navigation to User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Navigation to Game.
        /// </summary>
        public ICollection<Game> Games { get; set; }

        /// <summary>
        /// Theme name.
        /// </summary>
        public string Name { get; set; }
    }
}
