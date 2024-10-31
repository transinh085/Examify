using Examify.Quiz.Infrastructure.Data;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.DeleteQuiz;

public class DeleteQuizHandler(QuizContext context) : IRequestHandler<DeleteQuizCommand, IResult>
{
    public async Task<IResult> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await context.Quizzes.FindAsync(request, cancellationToken);
        context.Quizzes.Remove(quiz);
        await context.SaveChangesAsync(cancellationToken);
        return TypedResults.NoContent();
    }
}