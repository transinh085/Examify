using Examify.Result.Entities;
using Examify.Result.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            Order = order,
            IsSelected = false,
        };
        
        await quizResultContext.AnswerResults.AddAsync(answer);
        
        return answer;
    }
    
    public async Task<AnswerResult?> FindById(Guid id)
    {
        return await quizResultContext.AnswerResults.FindAsync(id);
    }
    
    public async Task<bool> Update(AnswerResult answerResult)
    {
        quizResultContext.AnswerResults.Update(answerResult);
        
        return await quizResultContext.SaveChangesAsync() > 0;
    }
    
    public async Task<AnswerResult?> FindByQuestionResultIdAndOptionId(Guid questionResultId, Guid optionId)
    {
        return await quizResultContext.AnswerResults
            .Where(a => a.QuestionResultId == questionResultId && a.OptionId == optionId)
            .FirstOrDefaultAsync();
    }
}

