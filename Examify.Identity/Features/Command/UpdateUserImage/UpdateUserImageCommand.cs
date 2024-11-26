using FluentValidation;
using MediatR;
using Examify.Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Examify.Identity.Features.Command.UpdateUserImage;

public record UpdateUserImageCommand(string Id,string ImageUrl) : IRequest<IResult>;

public class UpdateUserImageValidator : AbstractValidator<UpdateUserImageCommand>
{
    public UpdateUserImageValidator(IdentityContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty();
            
        RuleFor(x => x.ImageUrl).NotEmpty();
    }
}