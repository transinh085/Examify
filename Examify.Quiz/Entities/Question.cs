using Examify.Core.Entitites;
using Examify.Quiz.Enums;

namespace Examify.Quiz.Entities;

public class Question : BaseEntity
{
    public string Content { get; set; }
    
    public int Duration { get; set; }
    
    public int Points { get; set; }
    
    public QuestionType Type { get; set; }
    
    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; }
}