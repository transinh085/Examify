using AutoMapper;
using Examify.Quiz.Repositories.Questions;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.UpdateQuestion;

public class UpdateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper) : IRequestHandler<UpdateQuestionCommand, IResult>
{
    public async Task<IResult> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entities.Question>(request);
        await questionRepository.UpdateQuestion(entity, cancellationToken);
        return TypedResults.Ok();
    }
}