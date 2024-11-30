
namespace Examify.Result.Infrastructure.Data;

public class QuizResultSeeder : IDbSeeder<QuizResultContext>
{
    public Task SeedAsync(QuizResultContext context)
    {
        if (context.QuizResults.Any())
        {
            return Task.CompletedTask;
        }
        
        // seed data here
        
        return context.SaveChangesAsync();
    }
}