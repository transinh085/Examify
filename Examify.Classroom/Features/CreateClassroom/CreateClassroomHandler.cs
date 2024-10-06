using Examify.Classroom.Data;
using MediatR;

namespace Examify.Classroom.Features.CreateClassroom;

public class CreateClassroomHandler(ILogger<CreateClassroomHandler> logger, ClassroomContext context) : IRequestHandler<CreateClassroomCommand, Entities.Classroom>
{
    public async Task<Entities.Classroom> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating classroom with name {Name} and description {Description}", request.Name, request.Description);
        var classroom = new Entities.Classroom { Name = request.Name, Description = request.Description };
        await context.Classrooms.AddAsync(classroom, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return classroom;
    }
}