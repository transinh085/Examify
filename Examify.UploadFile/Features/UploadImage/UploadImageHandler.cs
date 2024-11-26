using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;

namespace Examify.UploadFile.Features.UploadImage;

public class UploadImageHandler(Cloudinary cloudinary) : IRequestHandler<UploadImageCommand, IResult>
{
    public async Task<IResult> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(request.File.FileName, request.File.OpenReadStream())
        };

        var uploadResult = await cloudinary.UploadAsync(uploadParams);

        var uploadResponse = new UploadImageResponse
        {
            Url = uploadResult.SecureUrl.ToString()
        };

        return TypedResults.Ok(uploadResponse);
    }
}