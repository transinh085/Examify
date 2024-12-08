using Examify.Result.Entities;

namespace Examify.Result.Repositories.QuestionResults;

public interface IQuestionResultRepository
{
    Task<QuestionResult> Create(Guid quizResultId, string questionId, int order);

    Task<QuestionResult?> FindById(Guid id);

    Task<bool> Update(QuestionResult questionResult);

    Task<bool> DeleteByQuestionId(Guid id);
}

