using Examify.Result.Entities;

namespace Examify.Result.Repositories;

public interface IQuizResultRepository
{
    Task<QuizResult> Create(string userId, string quizId, int attemptedNumber);
    
    Task<QuizResult?> FindById(Guid id);
    
    Task<bool> Exists(Guid quizResultId);
    
    Task<bool> SaveChangesAsync();

    Task<int> CountQuizAttempts(Guid Id, CancellationToken cancellationToken);
}
