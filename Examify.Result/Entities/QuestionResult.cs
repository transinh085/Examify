﻿using Examify.Core.Entitites;

namespace Examify.Result.Entities;

public class QuestionResult : BaseEntity
{
    public Guid QuizResultId { get; set; }
    public Guid QuestionId { get; set; }
    
    public int Order { get; set; }
    public bool IsCorrect { get; set; }
    
    public DateTime SubmittedAt { get; set; }
}