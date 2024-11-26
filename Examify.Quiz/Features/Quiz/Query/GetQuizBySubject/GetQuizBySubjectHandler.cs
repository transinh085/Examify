using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizBySubject;

public class GetQuizBySubjectHandler : IRequestHandler<GetQuizBySubjectQuery, IResult>
{
    public Task<IResult> Handle(GetQuizBySubjectQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}