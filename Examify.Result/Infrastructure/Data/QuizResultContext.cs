using Examify.Core.BaseDbContext;
using Examify.Result.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Infrastructure.Data;

/// <remarks>
/// Add migrations using the following command inside the 'Examify.Result' project directory:
///
/// dotnet ef migrations add --context QuizResultContext [migration-name] -o Infrastructure/Data/Migrations
/// </remarks>
public class QuizResultContext(DbContextOptions options) : BaseDbContext(options)
{
    public DbSet<QuizResult> QuizResults { get; init; }
    public DbSet<QuestionResult> QuestionResults { get; init; }
    public DbSet<AnswerResult> AnswerResults { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizResultContext).Assembly);
    }
}