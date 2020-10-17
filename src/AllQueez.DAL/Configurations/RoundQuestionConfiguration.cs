using AllQueez.Common.Constants;
using AllQueez.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AllQueez.DAL.Configurations
{
    /// <summary>
    /// EF Core Configuration for Round question entity.
    /// </summary>
    public class RoundQuestionConfiguration : IEntityTypeConfiguration<RoundQuestion>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<RoundQuestion> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TableConstants.RoundQuestions, SchemaConstants.RoundQuestion)
                .HasKey(roundQuestion => roundQuestion.Id);

            builder.HasOne(roundQuestion => roundQuestion.Question)
                .WithMany(question => question.RoundQuestions)
                .HasForeignKey(roundQuestion => roundQuestion.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(roundQuestion => roundQuestion.Round)
                .WithMany(round => round.RoundQuestions)
                .HasForeignKey(roundQuestion => roundQuestion.RoundId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
