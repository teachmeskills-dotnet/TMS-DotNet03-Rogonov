using AllQueez.DAL.Interfaces;
using System.Collections.Generic;

namespace AllQueez.DAL.Entities
{
    /// <summary>
    /// Rounds.
    /// </summary>
    public class Round : IHasDbIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

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
        /// Navigation to round questions.
        /// </summary>
        public ICollection<RoundQuestion> RoundQuestions { get; set; }
    }
}