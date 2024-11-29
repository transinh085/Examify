using Catalog;
using Examify.Catalog.Repositories.Grades;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Examify.Catalog.Grpc;

public class GradeService(IGradeRepository gradeRepository) : Grade.GradeBase
{
    public override async Task<GetGradeResponse> GetGrade(GradeRequest request, ServerCallContext context)
    {
        var grade = await gradeRepository.FindById(Guid.Parse(request.Id));

        if (grade is null)
        {
            return new GetGradeResponse
            {
                Empty = new Empty()
            };
        }
        return new GetGradeResponse
        {
            Grade = new GradeReply
            {
                Id = grade.Id.ToString(),
                Name = grade.Name,
            }
            
        };
    }
}