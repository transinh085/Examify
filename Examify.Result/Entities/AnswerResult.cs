﻿using Examify.Core.Entitites;

namespace Examify.Result.Entities;

public class AnswerResult : BaseEntity
{
    public Guid QuestionResultId { get; set; }

    public QuestionResult QuestionResult { get; set; }

    public Guid OptionId { get; set; }

    public int Order { get; set; }

    public bool IsSelected { get; set; }
}