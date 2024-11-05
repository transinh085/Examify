using Examify.Core.Endpoints;
using Examify.Result.Hubs;
using Examify.Result.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Examify.Result.Features.Sample;

public class SampleEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/sample", async(
            IHubContext< ResultHub, IResultHub > hubContext
            ) =>
        {
            await hubContext.Clients.All.SendMessage("Hello from SampleEndpoint");
            await hubContext.Clients.All.TestMe("Hello from SampleEndpoint");
        });
    }
}