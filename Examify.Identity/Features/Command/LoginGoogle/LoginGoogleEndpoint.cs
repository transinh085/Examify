using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.Command.LoginGoogle;

public class LoginGoogleEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/login/google",
            async (LoginGoogleCommand command, ISender sender) => await sender.Send(command));
    }
}