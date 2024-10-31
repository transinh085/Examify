using Examify.Core.BaseDbContext;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Infrastructure.Data;

/// <remarks>
/// Add migrations using the following command inside the 'Examify.Quiz' project directory:
///
/// dotnet ef migrations add --context QuizContext [migration-name] -o Infrastructure/Data/Migrations
/// </remarks>
public class QuizContext(DbContextOptions options) : BaseDbContext(options)
{
    public DbSet<Entities.Quiz> Quizzes { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizContext).Assembly);
    }
}