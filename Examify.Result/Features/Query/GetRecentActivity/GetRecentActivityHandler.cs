using Examify.Result.Repositories;
using MediatR;

namespace Examify.Result.Features.Query.GetRecentActivity;

public class GetRecentActivityHandler(IQuizResultRepository resultRepository, ILogger<GetRecentActivityHandler> logger) : IRequestHandler<GetRecentActivityQuery, IResult>
{
    public async Task<IResult> Handle(GetRecentActivityQuery request, CancellationToken cancellationToken)
    {
        var result = await resultRepository.GetListRecentActivity(request.UserId, request.GetPageNumber, request.GetPageSize);
        return TypedResults.Ok(result);
    }
}
