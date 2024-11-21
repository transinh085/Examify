using Examify.Result.Repositories;
using MediatR;
using Result;

namespace Examify.Quiz.Features.Result.Command.CreateQuizResult;

public class CreateQuizResultHandler (IQuizResultRepository quizResultRepository, global::Result.Quiz.QuizClient quizClient) : IRequestHandler<CreateQuizResultCommand, IResult>
{
    public async Task<IResult> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
    {
        var populatedQuiz = quizClient.GetQuiz(new QuizRequest
        {
            Id = request.QuizId,
        });
        
       
        // Your logic here
        return Results.Ok($"{populatedQuiz.Title} quiz result created"); 
    }
}