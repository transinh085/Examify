using Examify.Quiz.Infrastructure.Data;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.CreateQuiz;

public class CreateQuizHandler(QuizContext context) : IRequestHandler<CreateQuizCommand, IResult>
{
    public async Task<IResult> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = new Entities.Quiz();

        await context.Quizzes.AddAsync(quiz, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return TypedResults.Ok(quiz);
    }
}