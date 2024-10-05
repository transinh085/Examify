using Ardalis.Result;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.CreateUser;

public class CreateUserEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users", async (CreateUserCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Result.Created(result);
        });
    }
}