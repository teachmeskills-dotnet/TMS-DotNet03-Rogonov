namespace AllQueez.DAL.Entities
{
    /// <summary>
    /// Round questions.
    /// </summary>
    public class RoundQuestion
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Round id.
        /// </summary>
        public int RoundId { get; set; }

        /// <summary>
        /// Navigation to round.
        /// </summary>
        public Round Round { get; set; }

        /// <summary>
        /// Question id.
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Navigation to question.
        /// </summary>
        public Question Question { get; set; }
    }
}
