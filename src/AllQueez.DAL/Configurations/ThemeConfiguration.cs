using AllQueez.Common.Constants;
using AllQueez.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AllQueez.DAL.Configurations
{
    /// <summary>
    /// EF Core Configuration for Theme entity.
    /// </summary>
    public class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TableConstants.Themes, SchemeConstants.Theme)
                .HasKey(theme => theme.Id);

            builder.Property(theme => theme.Name)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthMedium);

            builder.HasOne(theme => theme.User)
                .WithMany(user => user.Themes)
                .HasForeignKey(theme => theme.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
