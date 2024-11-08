using AutoMapper;
using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.UpdateQuiz;

public class UpdateQuizHandler(IQuizRepository quizRepository, IMapper mapper) : IRequestHandler<UpdateQuizCommand, IResult>
{
    public async Task<IResult> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = mapper.Map<Entities.Quiz>(request);
        quizRepository.UpdateQuiz(quiz, cancellationToken);
        return TypedResults.Ok(quiz);
    }
}