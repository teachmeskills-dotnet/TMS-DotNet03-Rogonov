using System.ComponentModel.DataAnnotations;

namespace AllQueez.Web.ViewModels
{
    public class ThemeActionsViewModel
    {
        /// <summary>
        /// Theme name.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}