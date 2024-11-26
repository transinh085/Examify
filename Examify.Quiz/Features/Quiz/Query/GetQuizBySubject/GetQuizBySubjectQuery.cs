using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizBySubject;

public record GetQuizBySubjectQuery(Guid CategoryId) : IRequest<IResult>;