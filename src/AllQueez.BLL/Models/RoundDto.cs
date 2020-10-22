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
        /// User identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Game id.
        /// </summary>
        public int GameId { get; set; }

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
