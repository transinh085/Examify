
using Examify.Result.Entities;

namespace Examify.Result.Repositories;

public interface IAnswerResultRepository
{
    Task<AnswerResult> Create(Guid questionResultId, string optionId, int order);
   
}

