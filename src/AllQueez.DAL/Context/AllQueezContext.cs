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

        /// <summary>
        /// Rounds.
        /// </summary>
        public DbSet<Round> Rounds { get; set; }

        /// <summary>
        /// Questions.
        /// </summary>
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new ThemeConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new RoundConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
