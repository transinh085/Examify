using Examify.Result.Repositories;
using MediatR;
using Result;

namespace Examify.Result.Features.Command.UpdateQuestionResult;

public class UpdateQuestionResultHandler (
    IQuizResultRepository quizResultRepository, 
    IQuestionResultRepository questionResultRepository,
    IAnswerResultRepository answerResultRepository,
    QuestionGrpcService.QuestionGrpcServiceClient questionGrpcServiceClient) : IRequestHandler<UpdateQuestionResultCommand, IResult>
{
    public async Task<IResult> Handle(UpdateQuestionResultCommand request, CancellationToken cancellationToken)
    {
        var questionResult = await questionResultRepository.FindById(request.QuestionResultId);
        
        if (questionResult == null)
        {
            return Results.NotFound("Question result not found");
        }
        
        var populatedQuestion = questionGrpcServiceClient.GetQuestion(new QuestionRequest
        {
            Id = questionResult.QuestionId.ToString(),
        });
        
        // save answers
        foreach (var requestAnswer in request.Answers)
        {
            var answerResult = await answerResultRepository.FindByQuestionResultIdAndOptionId(request.QuestionResultId, Guid.Parse(requestAnswer));
            answerResult.IsSelected = true;
            await answerResultRepository.Update(answerResult);
        }
        
        // compare answers to calculate points
        
        var correctAnswers = populatedQuestion.Options
            .Where(o => o.IsCorrect)
            .Select(o => o.Id)
            .ToHashSet();
        
        var areEqual = correctAnswers.SetEquals(request.Answers);
        
        questionResult.IsCorrect = areEqual;
        questionResult.Points = areEqual ? populatedQuestion.Points : 0;
        questionResult.TimeTaken = request.TimeTaken;
        
        await questionResultRepository.Update(questionResult);
        
        return Results.Ok(new
        {
            IsCorrect = areEqual,
            CorrectOptions = correctAnswers,
        }); 
    }
}