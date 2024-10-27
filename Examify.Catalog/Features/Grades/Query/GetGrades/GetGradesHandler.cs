using Examify.Catalog.Repositories.Grades;
using MediatR;

namespace Examify.Catalog.Features.Grades.Query.GetGrades;

public class GetGradesHandler(IGradeRepository gradeRepository) : IRequestHandler<GetGradesQuery, IResult>
{
    public async Task<IResult> Handle(GetGradesQuery request, CancellationToken cancellationToken)
    {
        var grades = await gradeRepository.GetAll(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize
        );
        
        return Results.Ok(grades);
    }
}