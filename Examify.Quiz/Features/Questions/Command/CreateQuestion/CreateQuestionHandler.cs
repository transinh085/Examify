using AutoMapper;
using Examify.Quiz.Entities;
using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Questions;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.CreateQuestion;

public class CreateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper) : IRequestHandler<CreateQuestionCommand, IResult>
{
    public async Task<IResult> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = mapper.Map<Question>(request);
        await questionRepository.CreateQuestion(question, cancellationToken);
        
        return TypedResults.Created();
    }
}