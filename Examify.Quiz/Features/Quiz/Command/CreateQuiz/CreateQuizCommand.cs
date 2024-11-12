using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.CreateQuiz;

public record CreateQuizCommand(String UserId) : IRequest<IResult>;