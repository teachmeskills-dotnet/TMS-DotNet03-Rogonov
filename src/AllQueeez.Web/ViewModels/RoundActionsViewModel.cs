using System.ComponentModel.DataAnnotations;

namespace AllQueez.Web.ViewModels
{
    public class RoundActionsViewModel
    {
        /// <summary>
        /// Game Id.
        /// </summary>
        [Required]
        public int GameId { get; set; }

        /// <summary>
        /// Round title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Question Id.
        /// </summary>
        public int QuestionId { get; set; }
    }
}