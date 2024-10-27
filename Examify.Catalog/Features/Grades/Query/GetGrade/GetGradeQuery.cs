using MediatR;

namespace Examify.Catalog.Features.Grades.Query.GetGrade;

public record GetGradeQuery(Guid Id) : IRequest<IResult>;
