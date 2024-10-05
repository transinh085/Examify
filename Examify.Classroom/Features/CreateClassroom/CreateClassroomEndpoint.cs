using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Classroom.Features.CreateClassroom;

public class CreateClassroomEndpoint() : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/classrooms", async (CreateClassroomCommand command, ISender sender) =>
        {
            var classroom = await sender.Send(command);
            return classroom;
        });
    }
}