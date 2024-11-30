using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.SearchQuiz;

public record SearchQuizCommand : IRequest<IResult>;