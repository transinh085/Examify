using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetAllQuiz;

public record GetAllQuizQuery(int pageSize, int pageNumber) : IRequest<IResult>;