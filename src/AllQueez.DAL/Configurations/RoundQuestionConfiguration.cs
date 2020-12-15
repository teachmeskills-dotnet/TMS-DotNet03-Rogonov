using AllQueez.Common.Constants;
using AllQueez.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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

            builder.ToTable(TableConstants.RoundQuestions, SchemaConstants.Round)
                .HasKey(roundQuestion => roundQuestion.Id);
        }
    }
}
