using System;
using System.Collections.Generic;
using System.Text;

namespace AllQueez.Common.Interfaces
{
    /// <summary>
    /// Interface for identity implementation.
    /// </summary>
    public interface IHasDbIdentity
    {
        /// <summary>
        /// Identitfier.
        /// </summary>
        public int Id { get; set; }
    }
}
