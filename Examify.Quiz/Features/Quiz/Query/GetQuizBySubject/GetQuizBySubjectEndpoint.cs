using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizBySubject;

public class GetQuizBySubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quiz/subject/{subjectId:guid}",
            async (Guid subjectId, ISender sender) => await sender.Send(new GetQuizBySubjectQuery(subjectId)));
    }
}