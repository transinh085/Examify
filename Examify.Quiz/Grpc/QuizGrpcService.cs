using Examify.Quiz.Dtos;
using Examify.Quiz.Repositories.Quiz;
using Grpc.Core;
using Quiz;

namespace Examify.Quiz.Grpc
{
    public class QuizGrpcService(
        IQuizRepository quizRepository,
        ILogger<QuizGrpcService> logger) : global::Quiz.QuizGrpcService.QuizGrpcServiceBase
    {
        public override async Task<QuizReply> GetQuiz(QuizRequest request, ServerCallContext context)
        {
            logger.LogInformation("GRPC GetQuiz is called {quizId} {quizCode}", request.Id, request.Code);
            PopulatedQuizDto? quiz;
            // quiz = await quizRepository.GetQuizById("01937d4b-6f1e-7690-8350-4852408201a1");
            if (request.Id != "")
            {
                logger.LogInformation("GRPC GetQuiz request received: {Id}", request.Id);
                quiz = await quizRepository.GetQuizById(request.Id);
            }
            else
            {
                logger.LogInformation("GRPC GetQuiz request received: {Code}", request.Code);
                quiz = await quizRepository.GetQuizByCode(request.Code);
            }

            if (quiz == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Quiz not found."));
            }

            var reply = new QuizReply
            {
                Id = quiz.Id.ToString(),
                Title = quiz.Title,
                Description = quiz.Description ?? "",
                Code = quiz.Code ?? "",
                UserTimer = quiz.UserTimer,
                IsStart = quiz.IsStart,
                StartTime = quiz.StartTime.ToString(),
                EndTime = quiz.EndTime.ToString(),
                RandomQuestions = quiz.RandomQuestions,
                RandomOptions = quiz.RandomOptions,
                Visibility = (Visibility) quiz.Visibility,
                PlayTime = quiz.PlayTime.ToString(),
                Questions =
                {
                    quiz.Questions.Select(q => new QuizQuestionMessage()
                    {
                        Id = q.Id.ToString(),
                        Content = q.Content,
                        Duration = q.Duration,
                        Type = q.Type.ToString(),
                        Options =
                        {
                            q.Options.Select(o => new QuizOptionMessage()
                            {
                                Id = o.Id.ToString(),
                                Content = o.Content,
                                IsCorrect = o.IsCorrect
                            })
                        }
                    })
                },
                Cover = quiz.Cover
            };
            return reply;
        }
    }
}