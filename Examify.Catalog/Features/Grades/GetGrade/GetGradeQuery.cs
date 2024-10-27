using MediatR;

namespace Examify.Catalog.Features.Grades.GetGrade;

public record GetGradeQuery(Guid Id) : IRequest<IResult>;
