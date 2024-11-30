using System.IO.Pipelines;
using Examify.Core.Pagination;
using MediatR;

namespace Examify.Infrastructure.Behaviors;

public class PaginationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : PageRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        request.PageNumber ??= 1;
        request.PageSize ??= 8;
        
        return await next();
    }
}