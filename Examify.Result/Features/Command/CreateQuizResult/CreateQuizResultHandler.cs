using Examify.Result.Repositories;
using MediatR;
using Result;

namespace Examify.Quiz.Features.Result.Command.CreateQuizResult;

public class CreateQuizResultHandler (
    IQuizResultRepository quizResultRepository, 
    IQuestionResultRepository questionResultRepository,
    IAnswerResultRepository answerResultRepository,
    global::Result.Quiz.QuizClient quizClient) : IRequestHandler<CreateQuizResultCommand, IResult>
{
    public async Task<IResult> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
    {
        var populatedQuiz = quizClient.GetQuiz(new QuizRequest
        {
            Id = request.QuizId,
        });
        
        var createdQuizResult = await quizResultRepository.Create(
            request.UserId, request.QuizId, 1);

        foreach (var populatedQuizQuestion in populatedQuiz.Questions)
        {
            var createdQuestionResult = await questionResultRepository.Create(
                createdQuizResult.Id, populatedQuizQuestion.Id, 99);
            foreach (var option in populatedQuizQuestion.Options)
            {
                await answerResultRepository.Create(
                    createdQuestionResult.Id, option.Id, 99);
            }
        }

        await quizResultRepository.SaveChangesAsync();
        
        return Results.Ok(new
        {
            QuizResultId = createdQuizResult.Id,
            Message = "Quiz result created successfully",
        }); 
    }
}