using Examify.Quiz.Dtos;
using Examify.Quiz.Repositories.Questions;
using Quiz;
using Grpc.Core;

namespace Examify.Quiz.Grpc
{
    public class QuestionGrpcService(
        IQuestionRepository questionRepository,
        ILogger<QuestionGrpcService> logger) : global::Quiz.QuestionGrpcService.QuestionGrpcServiceBase
    {
        public override async Task<QuestionReply> GetQuestion(QuestionRequest request, ServerCallContext context)
        {
            logger.LogCritical("GRPC GetQuestion request received: {Id}", request.Id);
            PopulatedQuestionDto? question = await questionRepository.FindById(Guid.Parse(request.Id));

            if (question == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Question not found."));
            }

            var reply = new QuestionReply
            {
                Id = question.Id.ToString(),
                Content = question.Content,
                Duration = question.Duration,
                Points = question.Points,
                Options =
                {
                    question.Options.Select(o => new QuestionOptionMessage
                    {
                        Id = o.Id.ToString(),
                        Content = o.Content,
                        IsCorrect = o.IsCorrect
                    })
                }
            };
            return reply;
        }
    }
}