using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Command.PublishQuiz;

public class PublishQuizHandler(IQuizRepository quizRepository) : IRequestHandler<PublishQuizCommand, IResult>
{
    public async Task<IResult> Handle(PublishQuizCommand request, CancellationToken cancellationToken)
    {
        quizRepository.PublishQuiz(request.QuizId, cancellationToken);
        return TypedResults.NoContent();
    }
}