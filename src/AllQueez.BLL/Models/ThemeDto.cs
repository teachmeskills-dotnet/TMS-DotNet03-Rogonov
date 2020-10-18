using System;
using System.Collections.Generic;
using System.Text;

namespace AllQueez.BLL.Models
{
    /// <summary>
    /// Theme data tansfer object.
    /// </summary>
    public class ThemeDto
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
        /// Theme name.
        /// </summary>
        public string Name { get; set; }
    }
}
