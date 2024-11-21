using Examify.Result.Entities;
using Examify.Result.Infrastructure.Data;

namespace Examify.Result.Repositories;

public class AnswerResultRepository(QuizResultContext quizResultContext)
    : IAnswerResultRepository
{
    public async Task<AnswerResult> Create(Guid questionResultId, string optionId, int order)
    {
        AnswerResult answer = new AnswerResult
        {
            QuestionResultId = questionResultId,
            OptionId = Guid.Parse(optionId),
            IsSelected = false,
        };
        
        await quizResultContext.AnswerResults.AddAsync(answer);
        
        return answer;
    }
}

