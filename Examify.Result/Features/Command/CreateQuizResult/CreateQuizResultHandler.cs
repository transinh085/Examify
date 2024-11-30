using Examify.Result.Repositories;
using MediatR;
using Result;

namespace Examify.Result.Features.Command.CreateQuizResult;

public class CreateQuizResultHandler (
    IQuizResultRepository quizResultRepository, 
    IQuestionResultRepository questionResultRepository,
    IAnswerResultRepository answerResultRepository,
    QuizGrpcService.QuizGrpcServiceClient quizClient) : IRequestHandler<CreateQuizResultCommand, IResult>
{
    public async Task<IResult> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
    {
        var populatedQuiz = quizClient.GetQuiz(new QuizRequest
        {
            Id = request.QuizId.ToString(),
        });
        
        var createdQuizResult = await quizResultRepository.Create(
            request.UserId, request.QuizId.ToString(), 1);

        bool randomQuestion = true; // get from quiz setting
        bool randomOption = true; // get from quiz setting

        var questions = randomQuestion
            ? populatedQuiz.Questions.OrderBy(_ => Guid.NewGuid()).ToList()
            : populatedQuiz.Questions.ToList();

        foreach (var (populatedQuizQuestion, questionIndex) in questions.Select((q, i) => (q, i)))
        {
            var createdQuestionResult = await questionResultRepository.Create(
                createdQuizResult.Id,
                populatedQuizQuestion.Id,
                questionIndex); 
           
            var options = randomOption
                ? populatedQuizQuestion.Options.OrderBy(_ => Guid.NewGuid()).ToList()
                : populatedQuizQuestion.Options.ToList();

            foreach (var (option, optionIndex) in options.Select((o, i) => (o, i)))
            {
                await answerResultRepository.Create(
                    createdQuestionResult.Id,
                    option.Id,
                    optionIndex); 
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