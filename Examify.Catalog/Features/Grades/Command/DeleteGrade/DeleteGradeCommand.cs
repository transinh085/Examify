using MediatR;

namespace Examify.Catalog.Features.Grades.Command.DeleteGrade;

public record DeleteGradeCommand(Guid Id): IRequest<IResult>;