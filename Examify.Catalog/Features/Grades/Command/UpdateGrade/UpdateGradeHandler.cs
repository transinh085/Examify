using Ardalis.GuardClauses;
using Examify.Catalog.Repositories.Grades;
using MediatR;

namespace Examify.Catalog.Features.Grades.Command.UpdateGrade;

public class UpdateGradeHandler(IGradeRepository gradeRepository) : IRequestHandler<UpdateGradeCommand, IResult>
{
    public async  Task<IResult> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
    {
        var existingGrade = await gradeRepository.FindById(request.Id);
        Guard.Against.NotFound(request.Id, existingGrade);
        existingGrade.Name = request.Name;
        var updatedGrade = await gradeRepository.Update(existingGrade);
        return Results.Ok(updatedGrade);
    }
}