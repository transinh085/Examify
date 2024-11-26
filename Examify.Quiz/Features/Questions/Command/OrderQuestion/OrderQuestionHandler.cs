using Examify.Quiz.Repositories.Questions;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.OrderQuestion;

public class OrderQuestionHandler(IQuestionRepository repository) : IRequestHandler<OrderQuestionCommand, IResult>
{
    public async Task<IResult> Handle(OrderQuestionCommand request, CancellationToken cancellationToken)
    {
        await repository.UpdateOrder(request.QuestionId, request.Order, cancellationToken);
        return TypedResults.NoContent();
    }
}