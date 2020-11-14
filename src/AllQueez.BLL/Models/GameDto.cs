using System;

namespace AllQueez.BLL.Models
{
    /// <summary>
    /// Game data tansfer object.
    /// </summary>
    public class GameDto
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
        /// Theme Id.
        /// </summary>
        public int ThemeId { get; set; }

        public string ThemeName { get; set; }

        /// <summary>
        /// Game title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Game date.
        /// </summary>
        public DateTime? Date { get; set; }
    }
}
