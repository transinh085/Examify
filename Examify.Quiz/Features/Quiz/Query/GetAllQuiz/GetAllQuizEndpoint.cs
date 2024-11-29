using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetAllQuiz;

public class GetAllQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quizzes", async (ISender sender) => await sender.Send(new GetAllQuizQuery()))
            .Produces<List<Entities.Quiz>>();
    }
}