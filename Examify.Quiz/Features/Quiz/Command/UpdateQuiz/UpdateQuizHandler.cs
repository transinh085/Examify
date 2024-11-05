using AutoMapper;
using Examify.Quiz.Infrastructure.Data;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.UpdateQuiz;

public class UpdateQuizHandler(QuizContext context, IMapper mapper) : IRequestHandler<UpdateQuizCommand, IResult>
{
    public async Task<IResult> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = mapper.Map<Entities.Quiz>(request);
        
        context.Quizzes.Update(quiz);
        await context.SaveChangesAsync(cancellationToken);
        
        return TypedResults.Ok(quiz);
    }
}