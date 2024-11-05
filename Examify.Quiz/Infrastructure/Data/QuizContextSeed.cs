using Examify.Quiz.Enums;

namespace Examify.Quiz.Infrastructure.Data;

public class QuizContextSeed : IDbSeeder<QuizContext>
{
    public Task SeedAsync(QuizContext context)
    {
        if (context.Quizzes.Any())
        {
            return Task.CompletedTask;
        }
        
        context.Quizzes.AddAsync(new Entities.Quiz
        {
            Id = Guid.NewGuid(),
            Title = "Test Quiz",
            Cover = "https://example.com/cover.jpg",
            Description = "This is a test quiz",
            Visibility = Visibility.Public,
            SubjectId = Guid.NewGuid(),
            GradeId = Guid.NewGuid(),
            LanguageId = Guid.NewGuid(),
            OwnerId = Guid.NewGuid(),
            IsPublished = true
        });

        context.Quizzes.AddAsync(new Entities.Quiz
        {
            Id = Guid.NewGuid(),
            Title = "Another Test Quiz",
            Cover = "https://example.com/cover.jpg",
            Description = "This is another test quiz",
            Visibility = Visibility.Public,
            SubjectId = Guid.NewGuid(),
            GradeId = Guid.NewGuid(),
            LanguageId = Guid.NewGuid(),
            OwnerId = Guid.NewGuid(),
            IsPublished = true
        });
        
        return context.SaveChangesAsync();
    }
}