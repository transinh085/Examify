using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.GetUsers;

public class GetUsersEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", (ISender sender) =>
        {
            return sender.Send(new GetUsersQuery());
        });
    }
}