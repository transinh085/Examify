using MediatR;

namespace Examify.Catalog.Features.Grades.DeleteGrade;

public record DeleteGradeCommand(Guid Id): IRequest<IResult>;