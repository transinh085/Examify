
using Examify.Result.Entities;

namespace Examify.Result.Repositories;

public interface IQuizResultRepository
{
    Task<QuizResult> Create(string userId);
}