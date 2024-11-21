using Examify.Result.Entities;
using Examify.Result.Infrastructure.Data;

namespace Examify.Result.Repositories;

public class QuestionResultRepository(QuizResultContext quizResultContext)
    : IQuestionResultRepository
{
    public async Task<QuestionResult> Create(Guid quizResultId, string questionId, int order)
    {
        QuestionResult questionResult = new QuestionResult
        {
            QuizResultId = quizResultId,
            QuestionId = Guid.Parse(questionId),
            IsCorrect = false,
            Order = order,
            Points = 0,
        };
        
        await quizResultContext.QuestionResults.AddAsync(questionResult);
        
        return questionResult;
    }
}

