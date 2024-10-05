using Ardalis.Result;
using Examify.Identity.Interfaces;
using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.DeleteUser;

public record DeleteUserCommand(string Id) : IRequest<Result>;