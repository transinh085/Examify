using Classroom;
using Examify.Classroom.Domain;
using Grpc.Core;

namespace Examify.Classroom.Grpc;

public class ClassroomService : global::Classroom.Classroom.ClassroomBase
{
    private readonly ILogger<ClassroomService> _logger;
    
    public ClassroomService(ILogger<ClassroomService> logger)
    {
        _logger = logger;
    }
    
    public override Task<ClassroomReply> GetClassroom(ClassroomRequest request, ServerCallContext context)
    {
        _logger.LogInformation("GetClassroom called with id {Id}", request.Id);
        var id = request.Id;
        var classroom = ListClassrom.classrooms.FirstOrDefault(c => c.Id == id);
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