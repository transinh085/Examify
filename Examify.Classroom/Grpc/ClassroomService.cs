using Classroom;
using Examify.Classroom.Data;
using Grpc.Core;

namespace Examify.Classroom.Grpc;

public class ClassroomService(ILogger<ClassroomService> logger, ClassroomContext classroomContext) : global::Classroom.Classroom.ClassroomBase
{
    public override Task<ClassroomReply> GetClassroom(ClassroomRequest request, ServerCallContext context)
    {
        logger.LogInformation("GetClassroom called with id {Id}", request.Id);
        var id = request.Id;
        var classroom = classroomContext.Classrooms.Find(id);
        if (classroom == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Classroom with id {id} not found"));
        }
        return Task.FromResult(new ClassroomReply
        {
            Id = classroom.Id,
            Name = classroom.Name,
            Description = classroom.Description
        });
    }
}