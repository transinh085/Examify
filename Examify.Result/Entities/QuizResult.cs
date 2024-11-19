using Examify.Core.Entitites;

namespace Examify.Result.Entities;

public class QuizResult : BaseEntity
{
    public Guid QuizId { get; set; }
    
    public string UserId { get; set; }
    
    public int TotalPoints { get; set; }
    
    public int TimeTaken { get; set; }
    
    public int AttemptedNumber { get; set; }
    
    public DateTime SubmittedAt { get; set; }
}