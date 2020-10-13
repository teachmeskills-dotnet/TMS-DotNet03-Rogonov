using AllQueez.Common.Constants;
using AllQueez.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AllQueez.DAL.Configurations
{
    /// <summary>
    /// EF Core Configuration for Round entity.
    /// </summary>
    public class RoundConfiguration : IEntityTypeConfiguration<Round>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TableConstants.Rounds, SchemaConstants.Round)
                .HasKey(round => round.Id);

            builder.Property(round => round.Title)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthMedium);

            builder.Property(round => round.Type)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthMedium);

            builder.HasOne(round => round.User)
                .WithMany(user => user.Rounds)
                .HasForeignKey(round => round.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(round => round.Game)
                .WithMany(game => game.Rounds)
                .HasForeignKey(round => round.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
