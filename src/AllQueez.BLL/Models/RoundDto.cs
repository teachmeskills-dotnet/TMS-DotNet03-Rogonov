namespace AllQueez.BLL.Models
{
    /// <summary>
    /// Round data tansfer object.
    /// </summary>
    public class RoundDto
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Game id.
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Round title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Question Id.
        /// </summary>
        public int QuestionId { get; set; }
    }
}
