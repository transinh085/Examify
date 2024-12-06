namespace Examify.Result.Dtos;

public class GetLeaderBoardDto
{
	public List<UserStartQuizDto> users { get; set; }
	public List<QuestionStartQuizDto> questions { get; set; }
}

public class UserStartQuizDto
{
	public string Id { get; set; }
	public string Name { get; set; }
	public int Score { get; set; }
	public string Image { get; set; }
}

public class QuestionStartQuizDto
{
	public string Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public string Type { get; set; }
	public int Progress { get; set; }
	public int Correct { get; set; }
	public int Incorrect { get; set; }
	public List<OptionDto> Options { get; set; }
}

public class OptionDto
{
	public string Id { get; set; }
	public string Content { get; set; }

	public bool IsCorrect { get; set; }
}
