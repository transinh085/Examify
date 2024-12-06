namespace Examify.Quiz.Dtos;

public class GetQuizResultsDto
{
    public Guid Id { get; set; }
    
    public int TotalPoints { get; set; }
    
    public int TimeTaken { get; set; }
    
    public int AttemptedNumber { get; set; }
    
    public DateTime SubmittedAt { get; set; }
    
    public UserDto User { get; set; }
    
    public double CorrectRate { get; set; }
}

public class UserDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
}

