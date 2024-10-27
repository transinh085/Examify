using Ardalis.GuardClauses;
using Examify.Catalog.Repositories.Grades;
using MediatR;

namespace Examify.Catalog.Features.Grades.Command.DeleteGrade;

public class DeleteGradeHandler(IGradeRepository gradeRepository) : IRequestHandler<DeleteGradeCommand, IResult>
{
    public async Task<IResult> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
    {
        var existingGrade = await gradeRepository.FindById(request.Id);
        Guard.Against.NotFound(request.Id, existingGrade);
        await gradeRepository.Delete(existingGrade);
        return Results.NoContent();
    }
}