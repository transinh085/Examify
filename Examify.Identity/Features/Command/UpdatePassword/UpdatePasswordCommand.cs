﻿using System.Windows.Input;
using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Command.UpdatePassword;

public record UpdatePasswordCommand(string email,string OldPassword, string NewPassword) : IRequest<IResult>;

public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordValidator()
    {
        RuleFor(x => x.OldPassword).NotEmpty();
        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .NotEqual(x => x.OldPassword).WithMessage("New password must be different from the old password.");
    }
}