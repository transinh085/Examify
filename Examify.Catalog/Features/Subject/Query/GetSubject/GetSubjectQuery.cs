using MediatR;

namespace Examify.Catalog.Features.Subject.Query.GetSubject;

public record GetSubjectQuery(int Id) : IRequest<IResult>;