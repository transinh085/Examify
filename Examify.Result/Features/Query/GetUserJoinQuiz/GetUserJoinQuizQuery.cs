using Examify.Result.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Features.Query.GetUserJoinQuiz;

public record GetUserJoinQuizQuery(string Code) : IRequest<IResult>;