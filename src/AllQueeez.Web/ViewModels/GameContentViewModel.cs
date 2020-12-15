using System;

namespace AllQueez.Web.ViewModels
{
    /// <summary>
    /// Game content view model.
    /// </summary>
    public class GameContentViewModel
    {
        /// <summary>
        /// Game identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Theme identifier.
        /// </summary>
        public int ThemeId { get; set; }

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

        /// <summary>
        /// Round identifier.
        /// </summary>
        public int RoundId { get; set; }

        /// <summary>
        /// Round title.
        /// </summary>
        public string RoundTitle { get; set; }

        /// <summary>
        /// Question Id.
        /// </summary>
        public int QuestionId { get; set; }
    }
}
