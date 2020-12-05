using System;

namespace AllQueez.Web.ViewModels
{
    /// <summary>
    /// Game view model.
    /// </summary>
    public class GameRoundsViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Theme name.
        /// </summary>
        public string ThemeName { get; set; }

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
