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
    
    // get quizResult sorted by question order and answer order
    public async Task<QuizResult?> FindByIdWithQuestionsWithOptions(Guid id)
    {
        return await quizResultContext.QuizResults
            .AsNoTracking()
            .Include(r => r.QuestionResults)
            .ThenInclude(q => q.AnswerResults)
            .Where(r => r.Id == id)
            .Select(r => new QuizResult
            {
                Id = r.Id,
                UserId = r.UserId,
                QuizId = r.QuizId,
                AttemptedNumber = r.AttemptedNumber,
                TotalPoints = r.TotalPoints,
                TimeTaken = r.TimeTaken,
                CurrentQuestion = r.CurrentQuestion,
                QuestionResults = r.QuestionResults
                    .OrderBy(q => q.Order)
                    .Select(q => new QuestionResult
                    {
                        Id = q.Id,
                        Order = q.Order,
                        IsCorrect = q.IsCorrect,
                        Points = q.Points,
                        TimeTaken = q.TimeTaken,
                        SubmittedAt = q.SubmittedAt,
                        QuestionId = q.QuestionId,
                        AnswerResults = q.AnswerResults
                            .OrderBy(a => a.Order)
                            .ToList()
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<QuizResult?> FindById(Guid id)
    {
        return await quizResultContext.QuizResults
            .AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }
    public async Task<bool> Update(QuizResult quizResult)
    {
        quizResultContext.QuizResults.Update(quizResult);
        return true;
    }
    
    public async Task<bool> Exists(Guid quizResultId)
    {
        return await quizResultContext.QuizResults.AnyAsync(q => q.Id == quizResultId);
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return await quizResultContext.SaveChangesAsync() > 0;
    }

    public async Task<int> CountQuizAttempts(Guid Id, CancellationToken cancellationToken)
    {
        return await quizResultContext.QuizResults.Where(x => x.QuizId == Id).CountAsync();
    }
}