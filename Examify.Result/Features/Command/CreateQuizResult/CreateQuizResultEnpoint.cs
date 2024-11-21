using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Result.Features.Command.CreateQuizResult;

public class CreateQuizResultEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/quizzes/{quizId}/quiz-results",
                async (ClaimsPrincipal user, ISender sender, CreateQuizResultCommand command, string quizId) => 
                    await sender.Send(command with { QuizId = quizId, UserId = user.Identity.Name }))
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