using Catalog;
using Examify.Catalog.Repositories.Grades;
using Grpc.Core;

namespace Examify.Catalog.Grpc;

public class GradeService(IGradeRepository gradeRepository) : Grade.GradeBase
{
    public override async Task<GradeReply> GetGrade(GradeRequest request, ServerCallContext context)
    {
        var grade = await gradeRepository.FindById(Guid.Parse(request.Id));

        if (grade is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Grade not found"));
        }

        return new GradeReply
        {
            Id = grade.Id.ToString(),
            Name = grade.Name,
        };
    }
}