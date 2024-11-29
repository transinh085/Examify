using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizBySubject;

public class GetQuizBySubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quizzes/subjects",
            async ([AsParameters] GetQuizBySubjectQuery query, ISender sender) =>
            await sender.Send(query));
    }
}