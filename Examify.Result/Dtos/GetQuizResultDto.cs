namespace Examify.Quiz.Dtos;

public class GetQuizResultDto
{
    public Guid Id { get; set; }
    
    public int TotalPoints { get; set; }
    
    public int TimeTaken { get; set; }
    
    public int CurrentQuestion { get; set; }
    
    public QuizDto Quiz { get; set; }

    public List<QuestionResultDto> QuestionResults { get; set; }
}

public class QuizDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public string Code { get; set; }
}

public class QuestionResultDto
{
    public Guid Id { get; set; }
    
    public int Order { get; set; }
    
    public bool IsCorrect { get; set; }
    
    public int TimeTaken { get; set; }
    
    public int Points { get; set; }
    
    public QuestionDto Question { get; set; }
    
    public List<AnswerResultDto> AnswerResults { get; set; }
}

public class QuestionDto
{
    public string Id { get; set; }
    
    public string Content { get; set; }
    
    public string Type { get; set; }
    
    public int Duration { get; set; }
    
    public int Points { get; set; }
    
}

public class AnswerResultDto
{
    public Guid Id { get; set; }
    
    public int Order { get; set; }
    public bool IsSelected { get; set; }
    
    public OptionDto Option { get; set; }
}

public class OptionDto
{
    public string Id { get; set; }
    public string Content { get; set; }
    
    public bool IsCorrect { get; set; }
}