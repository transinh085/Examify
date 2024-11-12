using AutoMapper;
using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.UpdateQuiz;

public class UpdateQuizHandler(IQuizRepository quizRepository, IMapper mapper) : IRequestHandler<UpdateQuizCommand, IResult>
{
    public async Task<IResult> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
    {
        var findQuiz = await quizRepository.FindQuizById(request.Id, cancellationToken);
        if (findQuiz == null)
        {
            return TypedResults.NotFound("Quiz not found");
        }
        findQuiz.Title = request.Title;
        findQuiz.Description = request.Description;
        findQuiz.Cover = request.Cover;
        findQuiz.SubjectId = request.SubjectId;
        findQuiz.GradeId = request.GradeId;
        findQuiz.LanguageId = request.LanguageId;
        findQuiz.Visibility = request.Visibility;
        quizRepository.UpdateQuiz(findQuiz, cancellationToken);
        return TypedResults.Ok(findQuiz);
    }
}