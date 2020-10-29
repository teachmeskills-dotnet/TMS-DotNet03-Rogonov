using AllQueez.DAL.Interfaces;
using System.Collections.Generic;

namespace AllQueez.DAL.Entities
{
    /// <summary>
    /// Rounds.
    /// </summary>
    public class Round : IHasDbIdentity, IHasUserIdentity
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
        /// Game id.
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Navigation to game.
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Round title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Round type.
        /// </summary>
        public string Type { get; set; }
    }
}
