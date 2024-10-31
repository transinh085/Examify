using Examify.Core.Entitites;

namespace Examify.Quiz.Entities;

public class Option : BaseEntity
{
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
}