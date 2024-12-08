using Examify.Result.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examify.Result.Infrastructure.Data.Configurations;

public class QuestionResultConfiguration : IEntityTypeConfiguration<QuestionResult>
{
    public void Configure(EntityTypeBuilder<QuestionResult> builder)
    {
        builder.HasMany(x => x.AnswerResults)
            .WithOne(x => x.QuestionResult)
            .HasForeignKey(x => x.QuestionResultId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
