using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Infrastructure.Data.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Entities.Quiz>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Quiz> builder)
        {
            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Quiz)
                .HasForeignKey(x => x.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
