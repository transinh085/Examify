using Examify.Core.Pagination;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizBySubject;

public record GetQuizBySubjectQuery(Guid SubjectId) : IRequest<IResult>;