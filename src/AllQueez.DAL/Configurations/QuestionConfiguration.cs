using AllQueez.Common.Constants;
using AllQueez.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AllQueez.DAL.Configurations
{
    /// <summary>
    /// EF Core Configuration for Question entity.
    /// </summary>
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TableConstants.Questions, SchemaConstants.Question)
                .HasKey(question => question.Id);

            builder.Property(question => question.Title)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthMedium);

            builder.Property(question => question.Description)
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthTextarea);

            builder.Property(question => question.Comment)
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthLong);

            builder.Property(question => question.File)
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthShort);

            builder.Property(question => question.Path)
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthLong);

            builder.Property(question => question.Answer)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SqlMaxLengthTextarea);

            builder.HasOne(question => question.User)
                .WithMany(user => user.Questions)
                .HasForeignKey(question => question.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(question => question.RoundQuestions)
                .WithOne(roundQuestion => roundQuestion.Question)
                .HasForeignKey(roundQuestion => roundQuestion.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
