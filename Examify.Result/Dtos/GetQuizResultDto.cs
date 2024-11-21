namespace Examify.Quiz.Dtos;

public class GetQuizResultDto
{
    public Guid Id { get; set; }
    public List<QuestionResultDto> QuestionResults { get; set; }
}

public class QuestionResultDto
{
    public Guid Id { get; set; }
    
    public bool IsCorrect { get; set; }
   
    public QuestionDto Question { get; set; }
    
    public List<AnswerResultDto> AnswerResults { get; set; }
}

public class QuestionDto
{
    public string Id { get; set; }
    
    public string Content { get; set; }
    
    public int Duration { get; set; }
    
    public int Points { get; set; }
}

public class AnswerResultDto
{
    public Guid Id { get; set; }
    public bool IsSelected { get; set; }
    public OptionDto Options { get; set; }
}

public class OptionDto
{
    public string Id { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
}