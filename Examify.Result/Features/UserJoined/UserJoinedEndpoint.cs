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
            publishEndpoint.Publish<UserPasswordResetEvent>(new
            {
                UserId = UserId,
                Email = "transinh085@gmail.com",
                ResetLink = "https://examify.com/reset"
            });
            return TypedResults.Ok("ok");
        });
    }
}