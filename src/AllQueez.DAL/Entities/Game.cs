using AllQueez.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace AllQueez.DAL.Entities
{
    /// <summary>
    /// Games.
    /// </summary>
    public class Game : IHasDbIdentity, IHasUserIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string UserId { get; set; }

        /// <summary>
        /// Theme Id.
        /// </summary>
        public int ThemeId { get; set; }

        /// <summary>
        /// Navigation to User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Navigation to Theme.
        /// </summary>
        public Theme Theme { get; set; }

        /// <summary>
        /// Navigation to Round.
        /// </summary>
        public ICollection<Round> Rounds { get; set; }

        /// <summary>
        /// Game title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Game description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Game date.
        /// </summary>
        public DateTime? Date { get; set; }
    }
}
