namespace AllQueez.Web.ViewModels
{
    /// <summary>
    /// Rounds list view model.
    /// </summary>
    public class RoundsViewModel
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
        /// Round type.
        /// </summary>
        public string Type { get; set; }
    }
}
