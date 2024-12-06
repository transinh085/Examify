using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Examify.Result.Features.Command.CreateQuizResult;

public class CreateQuizResultEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/quiz-results",
                async (ClaimsPrincipal user, JoinQuizCommand command,  ISender sender) =>
                    await sender.Send(command with { UserId = user.Identity.Name }))
            .Produces<CreateQuizResultResponse>()
            .WithTags("Quiz Results")
            .RequireAuthorization();
    }
}

public class CreateQuizResultResponse // for swagger
{
    public Guid Id { get; set; }
    public string Message { get; set; }
}