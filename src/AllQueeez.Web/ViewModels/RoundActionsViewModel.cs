using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        /// Round type.
        /// </summary>
        [Required]
        public string Type { get; set; }
    }
}
