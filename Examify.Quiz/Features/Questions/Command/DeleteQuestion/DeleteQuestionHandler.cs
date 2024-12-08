using Examify.Events;
using Examify.Quiz.Repositories.Questions;
using MassTransit;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.DeleteQuestion;

public class DeleteQuestionHandler(IQuestionRepository questionRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<DeleteQuestionCommand, IResult>
{
    public async Task<IResult> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        await questionRepository.DeleteQuestionById(request.Id, cancellationToken);

        await publishEndpoint.Publish<QuestionDeletedEvent>(new
        {
            QuestionId = request.Id,
            DeletedAt = DateTime.UtcNow
        }, cancellationToken);

        return TypedResults.NoContent();
    }
}