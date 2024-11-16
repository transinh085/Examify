using Examify.Core.Entitites;
using Examify.Quiz.Enums;

namespace Examify.Quiz.Entities;

public class QuizSetting : BaseEntity
{
    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; }
    
    public string Code { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public bool RandomQuestions { get; set; }
    public bool RandomOptions { get; set; }
    
    public Visibility Visibility { get; set; } = Visibility.Private;
}