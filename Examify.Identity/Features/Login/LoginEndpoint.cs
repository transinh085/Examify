using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.Login;

public class LoginEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/login", async (LoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result;
        }).WithTags("Authentication");
    }
}