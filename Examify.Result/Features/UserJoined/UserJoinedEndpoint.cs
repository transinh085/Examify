using Examify.Core.Endpoints;
using Examify.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Examify.Result.Features.UserJoined;

public class UserJoinedEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("joined", async ([FromServices] IPublishEndpoint publishEndpoint, string UserId) =>
        {
            publishEndpoint.Publish<UserJoinedExamEvent>(new
            {
                UserId = UserId
            });
            return TypedResults.Ok("ok");
        });
    }
}