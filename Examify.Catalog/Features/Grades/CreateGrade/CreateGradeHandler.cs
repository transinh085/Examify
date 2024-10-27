using Examify.Catalog.Repositories.Grades;
using MediatR;

namespace Examify.Catalog.Features.Grades.CreateGrade;

public class CreateGradeHandler(IGradeRepository gradeRepository) : IRequestHandler<CreateGradeCommand, IResult>
{
    public async  Task<IResult> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
    {
        var grade = new Entities.Grade()
        {
            Name = request.Name
        };
        await gradeRepository.Create(grade);
        return Results.Created("uri", grade);
    }
}