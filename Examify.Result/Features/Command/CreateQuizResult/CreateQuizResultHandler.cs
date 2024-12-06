using Examify.Result.Repositories;
using MediatR;
using Result;

namespace Examify.Result.Features.Command.CreateQuizResult;

public class JoinQuizHandler (
    IQuizResultRepository quizResultRepository, 
    IQuestionResultRepository questionResultRepository,
    IAnswerResultRepository answerResultRepository,
    QuizGrpcService.QuizGrpcServiceClient quizClient,
    ILogger<JoinQuizHandler> logger
    ) : IRequestHandler<JoinQuizCommand, IResult>
{
    public async Task<IResult> Handle(JoinQuizCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating quiz result of quiz {QuizCode} for user {UserId}", request.Code, request.UserId);
        var populatedQuiz = quizClient.GetQuiz(new QuizRequest
        {
            Id = "",
            Code = request.Code
        });

        logger.LogInformation("Received quiz from quizService {quizId}", populatedQuiz.Id);
        
        int latestAttemptNumber = await quizResultRepository.GetLatestAttemptNumber(
            Guid.Parse(populatedQuiz.Id), request.UserId, cancellationToken);
        
        var createdQuizResult = await quizResultRepository.Create(
            request.UserId, populatedQuiz.Id, latestAttemptNumber + 1);
        
        bool randomQuestion = populatedQuiz?.RandomQuestions ?? false; 
        bool randomOption = populatedQuiz?.RandomOptions ?? false;
        
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