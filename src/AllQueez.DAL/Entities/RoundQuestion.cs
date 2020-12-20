using AllQueez.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllQueez.DAL.Entities
{
    /// <summary>
    /// Questions by rounds.
    /// </summary>
    public class RoundQuestion : IHasDbIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Round identifier.
        /// </summary>
        public int RoundId { get; set; }

        /// <summary>
        /// Question identifier.
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Navigation to round.
        /// </summary>
        public Round Round { get; set; }

        /// <summary>
        /// Navigation to question.
        /// </summary>
        public Question Question { get; set; }
    }
}
