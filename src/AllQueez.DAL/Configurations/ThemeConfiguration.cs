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
    public class ThemeConfiguration : IEntityTypeConfiguration<RoundQuestion>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<RoundQuestion> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TableConstants.Themes, SchemaConstants.Theme)
                .HasKey((System.Linq.Expressions.Expression<Func<RoundQuestion, object>>)(theme => (object)theme.Id));

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
