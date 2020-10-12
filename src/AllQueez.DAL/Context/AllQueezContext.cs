using AllQueez.DAL.Configurations;
using AllQueez.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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

        /// <summary>
        /// Themes.
        /// </summary>
        public DbSet<Theme> Themes { get; set; }

        /// <summary>
        /// Games.
        /// </summary>
        public DbSet<Game> Games { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new ThemeConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
