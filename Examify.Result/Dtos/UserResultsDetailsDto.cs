namespace Examify.Quiz.Dtos;

public class UserResultsDetailsDto
{
    public Guid Id { get; set; }
    
    public int TotalPoints { get; set; }
    
    public int TimeTaken { get; set; }
    
    public int AttemptedNumber { get; set; }
    
    public DateTime SubmittedAt { get; set; }
    
    public QuizDataDto Quiz { get; set; }
    
    public UserDataDto User { get; set; }
    
    public List<QuestionResultDataDto> QuestionResults { get; set; }
}

public class UserDataDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
}
public class QuizDataDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class QuestionResultDataDto
{
    public Guid Id { get; set; }
    
    public int Order { get; set; }
    
    public bool IsCorrect { get; set; }
    
    public int Points { get; set; }
    
    public int TimeTaken { get; set; }
    
    public QuestionDataDto Question { get; set; }
    
    public List<AnswerResultDataDto> AnswerResults { get; set; }
}

public class QuestionDataDto
{
    public string Id { get; set; }
    
    public string Content { get; set; }
    
    public string Type { get; set; }
    
    public int Duration { get; set; }
    
    public int Points { get; set; }
}

public class AnswerResultDataDto
{
    public Guid Id { get; set; }
    
    public int Order { get; set; }
    
    public bool IsSelected { get; set; }
    
    public OptionDataDto Option { get; set; }
}

public class OptionDataDto
{
    public string Id { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
}