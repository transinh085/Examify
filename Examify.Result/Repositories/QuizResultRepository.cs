using Examify.Result.Entities;
using Examify.Result.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Repositories;

public class QuizResultRepository(QuizResultContext context) : IQuizResultRepository
{
    private IQuizResultRepository _quizResultRepositoryImplementation;

    public async Task<QuizResult> Create(string userId)
    {
        return null;
    }

    public async Task<int> CountQuizAttempts(Guid Id, CancellationToken cancellationToken)
    {
        return await context.QuizResults.Where(x => x.QuizId == Id).CountAsync();
    }
}