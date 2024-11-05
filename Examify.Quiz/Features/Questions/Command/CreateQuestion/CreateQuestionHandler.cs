using AutoMapper;
using Examify.Quiz.Entities;
using Examify.Quiz.Infrastructure.Data;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.CreateQuestion;

public class CreateQuestionHandler(QuizContext context, IMapper mapper) : IRequestHandler<CreateQuestionCommand, IResult>
{
    public async Task<IResult> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = mapper.Map<Question>(request);
        await context.Questions.AddAsync(question, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return TypedResults.Created();
    }
}