using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetAllQuiz;

public record GetAllQuizQuery : IRequest<IResult>;