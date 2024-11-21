
using Examify.Result.Entities;

namespace Examify.Result.Repositories;

public interface IQuestionResultRepository
{
    Task<QuestionResult> Create(Guid quizResultId, string questionId, int order);
}

