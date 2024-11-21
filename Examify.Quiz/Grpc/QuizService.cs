using Examify.Quiz.Repositories.Quiz;
using Quiz;
using Grpc.Core;

namespace Examify.Quiz.Grpc
{
    public class QuizService(IQuizRepository quizRepository) : global::Quiz.Quiz.QuizBase
    {
        public override async Task<QuizReply> GetQuiz(QuizRequest request, ServerCallContext context)
        {
            var quiz = await quizRepository.GetQuizById(request.Id);
            return new QuizReply
            {
                Id = quiz.Id.ToString(),
                Title = "Ok"
            };
        }
    }
}