using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetAllQuiz;

public class GetAllQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quizzes", async (int pageSize, int pageNumber,ISender sender) => await sender.Send(new GetAllQuizQuery(pageSize, pageNumber)))
            .Produces<List<Entities.Quiz>>();
    }
}