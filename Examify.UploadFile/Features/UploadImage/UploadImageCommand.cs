using FluentValidation;
using MediatR;

namespace Examify.UploadFile.Features.UploadImage;

public record UploadImageCommand(IFormFile File) : IRequest<IResult>;

public class UploadImageValidator : AbstractValidator<UploadImageCommand>
{
    public UploadImageValidator()
    {
        RuleFor(x => x.File)
            .NotNull()
            .Must(file => 
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                return allowedExtensions.Contains(extension);
            })
            .WithMessage("Invalid file type. Only image files are allowed.");
    }
}

public class UploadImageResponse
{
    public string Url { get; set; }
}