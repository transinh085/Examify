using Examify.Quiz.Dtos;
using Examify.Quiz.Repositories.Quiz;
using Quiz;
using Grpc.Core;

namespace Examify.Quiz.Grpc
{
    public class QuizGrpcService(
        IQuizRepository quizRepository,
        ILogger<QuizGrpcService> logger) : global::Quiz.QuizGrpcService.QuizGrpcServiceBase
    {
        public override async Task<QuizReply> GetQuiz(QuizRequest request, ServerCallContext context)
        {
            logger.LogCritical("GRPC GetQuiz request received: {Id}", request.Id);
            PopulatedQuizDto? quiz = await quizRepository.GetQuizById(request.Id);

            if (quiz == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Quiz not found."));
            }

            var reply = new QuizReply
            {
                Id = quiz.Id.ToString(),
                Title = quiz.Title,
                Description = quiz.Description ?? "",
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
                }
            };
            return reply;
        }
    }
}