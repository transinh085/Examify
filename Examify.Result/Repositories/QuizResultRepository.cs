using Examify.Result.Entities;
using Examify.Result.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Repositories;

public class QuizResultRepository(QuizResultContext quizResultContext)
    : IQuizResultRepository
{
    public async Task<QuizResult> Create(string userId, string quizId, int attemptedNumber)
    {
        QuizResult quizResult = new QuizResult
        {
            UserId = userId,
            QuizId = Guid.Parse(quizId),
            AttemptedNumber = attemptedNumber,
            TotalPoints = 0,
            TimeTaken = 0,
            CurrentQuestion = 0,
        };
        
        await quizResultContext.QuizResults.AddAsync(quizResult);
        
        return quizResult;
    }
    
    public async Task<QuizResult?> FindById(Guid id)
    {
        return await quizResultContext.QuizResults
            .Include(r => r.QuestionResults) 
            .ThenInclude(q => q.AnswerResults) 
            .FirstOrDefaultAsync(r => r.Id == id); 
    }
    
    public async Task<bool> Exists(Guid quizResultId)
    {
        return await quizResultContext.QuizResults.AnyAsync(q => q.Id == quizResultId);
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return await quizResultContext.SaveChangesAsync() > 0;
    }
}

