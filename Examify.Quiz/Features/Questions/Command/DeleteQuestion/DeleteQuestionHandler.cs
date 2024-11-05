using Examify.Quiz.Entities;
using Examify.Quiz.Infrastructure.Data;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.DeleteQuestion;

public class DeleteQuestionHandler(QuizContext context) : IRequestHandler<DeleteQuestionCommand, IResult>
{
    public async Task<IResult> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        context.Questions.Remove(new Question() { Id = request.Id });
        await context.SaveChangesAsync(cancellationToken);
        return TypedResults.NoContent();
    }
}