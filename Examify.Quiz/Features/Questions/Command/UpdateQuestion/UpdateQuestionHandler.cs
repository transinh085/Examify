using MediatR;

namespace Examify.Quiz.Features.Questions.Command.UpdateQuestion;

public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, IResult>
{
    public Task<IResult> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}