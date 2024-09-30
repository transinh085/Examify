using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examify.Classroom.Features.GetClassrooms;

public class GetClassroomsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/classrooms", (ISender sender) => sender.Send(new GetClassroomsQuery()));
    }
}