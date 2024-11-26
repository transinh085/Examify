using MediatR;

namespace Examify.Quiz.Features.Questions.Command.UpdateQuestion;

public record UpdateQuestionCommand(Guid Id, string Content, int Duration, int Points, List<UpdateOptionsDto> Options) : IRequest<IResult>;

public class UpdateOptionsDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
}