using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.UploadImage;

public class UploadImageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/upload-image",
                async (IFormFile file, ISender sender) => await sender.Send(new UploadImageCommand(file)))
            .DisableAntiforgery();
    }
}