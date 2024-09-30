using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;
using Serilog;
using ValidationException = FluentValidation.ValidationException;

namespace Examify.Infrastructure.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> _validators,
    ILogger<ValidationBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults =
                await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            logger.LogInformation("Validating request: {Request}", request);
            var failures = validationResults.Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);
        }

        return await next();
    }
}