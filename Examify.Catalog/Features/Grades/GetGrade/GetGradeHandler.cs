using Ardalis.GuardClauses;
using Examify.Catalog.Repositories.Grades;
using MediatR;

namespace Examify.Catalog.Features.Grades.GetGrade;

public class GetGradeHandler(IGradeRepository gradeRepository) : IRequestHandler<GetGradeQuery, IResult>
{
    public async Task<IResult> Handle(GetGradeQuery request, CancellationToken cancellationToken)
    {
        var existingGrade = await gradeRepository.FindById(request.Id);
        Guard.Against.NotFound(request.Id, existingGrade);
        return TypedResults.Ok(existingGrade);
    }
}