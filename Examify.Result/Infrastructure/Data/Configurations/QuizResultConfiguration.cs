using Examify.Result.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examify.Result.Infrastructure.Data.Configurations;

public class QuizResultConfiguration : IEntityTypeConfiguration<QuizResult>
{
    public void Configure(EntityTypeBuilder<QuizResult> builder)
    {
        builder.HasMany(x => x.QuestionResults)
            .WithOne(x => x.QuizResult)
            .HasForeignKey(x => x.QuizResultId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
