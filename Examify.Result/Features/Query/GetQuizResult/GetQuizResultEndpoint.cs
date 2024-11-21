using Examify.Core.Endpoints;
using Examify.Quiz.Dtos;
using MediatR;

namespace Examify.Result.Features.Query.GetQuizResult;

public class GetQuizResultEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quiz-results/{id}", async (ISender sender, Guid id) => await sender.Send(new GetQuizResultQuery(id)))
            .Produces<GetQuizResultDto>()
            .WithTags("Quiz Results")
            .RequireAuthorization();
    }
}