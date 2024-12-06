using MediatR;

namespace Examify.Result.Features.Query.GetStartQuiz;

public record GetStartQuizQuery(string Code) : IRequest<IResult>;