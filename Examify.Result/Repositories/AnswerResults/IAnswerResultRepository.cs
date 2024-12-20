﻿using Examify.Result.Entities;

namespace Examify.Result.Repositories.AnswerResults;

public interface IAnswerResultRepository
{
    Task<AnswerResult> Create(Guid questionResultId, string optionId, int order);

    Task<AnswerResult?> FindById(Guid id);

    Task<AnswerResult?> FindByQuestionResultIdAndOptionId(Guid questionResultId, Guid optionId);

    Task<bool> Update(AnswerResult answerResult);
    Task<bool> DeleteByOptionIds(List<Guid> ids);
}

