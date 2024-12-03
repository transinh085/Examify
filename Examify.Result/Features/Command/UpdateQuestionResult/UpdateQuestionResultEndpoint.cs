using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Result.Features.Command.UpdateQuestionResult;

public class UpdateQuestionResultEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/question-results/{questionResultId}",
                async (ISender sender, UpdateQuestionResultCommand command, Guid questionResultId) =>
                    await sender.Send(command with { QuestionResultId = questionResultId }))
            .Produces<UpdateQuestionResultResponse>()
            .WithTags("Quiz Results")
            .RequireAuthorization();
    }
}

public class UpdateQuestionResultResponse 
{
    public bool IsCorrect { get; set; }
    public List<string> CorrectOptions { get; set; }
} 
