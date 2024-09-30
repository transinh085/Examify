using MediatR;

namespace Examify.Classroom.Features.CreateClassroom;

public class CreateClassroomHandler(ILogger<CreateClassroomHandler> logger) : IRequestHandler<CreateClassroomCommand, Domain.Classroom>
{
    public Task<Domain.Classroom> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating classroom with name {Name} and description {Description}", request.Name, request.Description);
        var classroom = new Domain.Classroom { Name = request.Name, Description = request.Description };
        return Task.FromResult(classroom);
    }
}