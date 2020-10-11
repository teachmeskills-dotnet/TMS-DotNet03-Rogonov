using AllQueez.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllQueez.DAL.Context
{
    /// <summary>
    /// AllQueez database context.
    /// </summary>
    public class AllQueezContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public AllQueezContext(DbContextOptions<AllQueezContext> options)
            : base(options)
        {
        }
    }
}
