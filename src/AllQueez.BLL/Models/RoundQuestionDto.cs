namespace AllQueez.BLL.Models
{
    /// <summary>
    /// RoundQuestion data transfer object.
    /// </summary>
    public class RoundQuestionDto
    {
        /// <summary>
        /// RoundQuestion identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Round identifier.
        /// </summary>
        public int RoundId { get; set; }

        /// <summary>
        /// Question identifier.
        /// </summary>
        public int QuestionId { get; set; }
    }
}
