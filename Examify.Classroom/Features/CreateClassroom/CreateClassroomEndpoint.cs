using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Classroom.Features.CreateClassroom;

public class CreateClassroomEndpoint(IMediator mediator) : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/classrooms", async (CreateClassroomCommand command) =>
        {
            var classroom = await mediator.Send(command);
            return classroom;
        });
    }
}