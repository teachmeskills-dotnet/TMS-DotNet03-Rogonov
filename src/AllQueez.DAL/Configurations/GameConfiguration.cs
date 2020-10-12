using AllQueez.Common.Constants;
using AllQueez.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AllQueez.DAL.Configurations
{
    /// <summary>
    /// EF Core Configuration for Game entity.
    /// </summary>
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TableConstants.Games, SchemeConstants.Game)
                .HasKey(game => game.Id);

            builder.Property(game => game.Title)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthMedium);

            builder.Property(theme => theme.Date)
                .HasColumnType(ConfigurationConstants.SqlDateFormat);

            builder.HasOne(game => game.User)
                .WithMany(user => user.Games)
                .HasForeignKey(game => game.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(game => game.Theme)
                .WithMany(theme => theme.Games)
                .HasForeignKey(game => game.ThemeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
