using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.CreateQuiz;

public class CreateQuizHandler(IQuizRepository _quizRepository) : IRequestHandler<CreateQuizCommand, IResult>
{
    public async Task<IResult> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var UserId = request.UserId;
        var quiz = await _quizRepository.CreateQuizEmpty(UserId, cancellationToken);
        return TypedResults.Ok(quiz);
    }
}