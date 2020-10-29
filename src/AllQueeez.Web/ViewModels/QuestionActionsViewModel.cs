using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllQueez.Web.ViewModels
{
    public class QuestionActionsViewModel
    {
        /// <summary>
        /// Title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// File.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Answer.
        /// </summary>
        [Required]
        public string Answer { get; set; }
    }
}
