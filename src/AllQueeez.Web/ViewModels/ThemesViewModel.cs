using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllQueez.Web.ViewModels
{
    /// <summary>
    /// Themes list view.
    /// </summary>
    public class ThemesViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
                
        /// <summary>
        /// Theme name.
        /// </summary>
        public string Name { get; set; }
    }
}
