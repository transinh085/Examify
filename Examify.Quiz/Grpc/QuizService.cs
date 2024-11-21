using Examify.Quiz.Dtos;
using Examify.Quiz.Repositories.Quiz;
using Quiz;
using Grpc.Core;

namespace Examify.Quiz.Grpc
{
    public class QuizService(IQuizRepository quizRepository) : global::Quiz.Quiz.QuizBase
    {
        public override async Task<QuizReply> GetQuiz(QuizRequest request, ServerCallContext context)
        {
            PopulatedQuizDto? quiz = await quizRepository.GetQuizById(request.Id);
            
            var reply = new QuizReply
            {
                Id = quiz.Id.ToString(),
                Questions = { quiz.Questions.Select(q => new Question
                {
                    Id = q.Id.ToString(),
                    Content = q.Content,
                    Duration = q.Duration,
                    Type = q.Type.ToString(),
                    Options = { q.Options.Select(o => new Option
                    {
                        Id = o.Id.ToString(),
                        Content = o.Content,
                        IsCorrect = o.IsCorrect
                    })}
                })}
            };
            return reply;
        }
    }
}