using Examify.Quiz.Dtos;
using Examify.Result.Repositories.QuizResults;
using MediatR;
using Result;

namespace Examify.Result.Features.Query.GetQuizResult;

public class GetQuizResultHandler(
    IQuizResultRepository quizResultRepository,
    QuizGrpcService.QuizGrpcServiceClient quizClient
) : IRequestHandler<GetQuizResultQuery, IResult>
{
    public async Task<IResult> Handle(GetQuizResultQuery request, CancellationToken cancellationToken)
    {
        var quizResult = await quizResultRepository.FindByIdWithQuestionsWithOptions(request.Id);

        if (quizResult is null)
        {
            return TypedResults.NotFound("Result not found.");
        }

        var populatedQuiz = quizClient.GetQuiz(new QuizRequest
        {
            Id = quizResult.QuizId.ToString(),
        });
      
        var quizResultDto = new GetQuizResultDto
        {
            Id = quizResult.Id,
            CurrentQuestion = quizResult.CurrentQuestion,
            TotalPoints = quizResult.TotalPoints,
            TimeTaken = quizResult.TimeTaken,
            
            Quiz = new QuizDto
            {
                Id = Guid.Parse(populatedQuiz.Id),
                Title = populatedQuiz.Title,
                Description = populatedQuiz.Description,
                Code = populatedQuiz.Code,
                UseTimer = populatedQuiz.UserTimer,
                IsStart = populatedQuiz.IsStart,
                IsPrivate = populatedQuiz.Visibility == Visibility.Private
            },
            
            QuestionResults = quizResult.QuestionResults.Select(qr => new QuestionResultDto
            {
                Id = qr.Id,
                Order = qr.Order,
                IsCorrect = qr.IsCorrect,
                TimeTaken = qr.TimeTaken,
                Points = qr.Points,
                Question = populatedQuiz.Questions
                        .FirstOrDefault(q => Guid.Parse(q.Id) == qr.QuestionId)
                    is QuizQuestionMessage question
                    ? new QuestionDto
                    {
                        Id = question.Id,
                        Content = question.Content,
                        Type = question.Type,
                        Duration = question.Duration,
                        Points = question.Points,
                    }
                    : new QuestionDto
                    {
                        Id = string.Empty,
                        Content = string.Empty,
                        Type = string.Empty,
                        Duration = 0,
                        Points = 0
                    },
                AnswerResults = qr.AnswerResults.Select(ar => new AnswerResultDto
                {
                    Id = ar.Id,
                    Order = ar.Order,
                    IsSelected = ar.IsSelected,
                    Option = populatedQuiz.Questions
                            .SelectMany(q => q.Options)
                            .FirstOrDefault(o => Guid.Parse(o.Id) == ar.OptionId)
                        is QuizOptionMessage option
                        ? new OptionDto
                        {
                            Id = option.Id,
                            Content = option.Content,
                            IsCorrect = quizResult.CurrentQuestion > qr.Order ? option.IsCorrect : false
                        }
                        : new OptionDto
                        {
                            Id = string.Empty,
                            Content = string.Empty,
                        }
                }).ToList()
            }).ToList()
        };
        return TypedResults.Ok(quizResultDto);
    }
}