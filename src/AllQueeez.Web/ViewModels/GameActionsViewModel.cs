using System;
using System.ComponentModel.DataAnnotations;

namespace AllQueez.Web.ViewModels
{
    public class GameActionsViewModel
    {
        /// <summary>
        /// Theme Id.
        /// </summary>
        [Required]
        public int ThemeId { get; set; }

        /// <summary>
        /// Game title.
        /// </summary>
        [Required]
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