using Catalog;
using Examify.Catalog.Repositories.Grades;
using Grpc.Core;

namespace Examify.Catalog.Grpc;

public class GradeService(IGradeRepository gradeRepository) : Grade.GradeBase
{
    public override async Task<GradeReply> GetGrade(GradeRequest request, ServerCallContext context)
    {
        var grade = await gradeRepository.FindById(new Guid(request.Id));
        return new GradeReply
        {
            Id = grade?.Id.ToString() ?? string.Empty, 
            Name = grade?.Name ?? string.Empty,
        }; 
    }
}