﻿using Examify.Result.Entities;
using Examify.Result.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Repositories.QuestionResults;

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
            TimeTaken = 0,
        };

        await quizResultContext.QuestionResults.AddAsync(questionResult);

        return questionResult;
    }

    public async Task<bool> DeleteByQuestionId(Guid id)
    {
        var list = quizResultContext.QuestionResults.Where(x => x.QuestionId == id);

        if (list != null)
        {
            quizResultContext.QuestionResults.RemoveRange(list);
            await quizResultContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<QuestionResult?> FindById(Guid id)
    {
        return await quizResultContext.QuestionResults.AsTracking(QueryTrackingBehavior.NoTracking)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> Update(QuestionResult questionResult)
    {
        quizResultContext.QuestionResults.Update(questionResult);
        await quizResultContext.SaveChangesAsync();
        return true;
    }
}