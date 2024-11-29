using Examify.Core.Endpoints;

namespace Examify.Notification.Features.Test;

public class TestEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/test", async () => await Task.FromResult("Test"))
            .WithTags("Test");
    }
}