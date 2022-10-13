using FluentValidation;
using MediatR;
using ValidationException = NETPCTest.Core.Exceptions.ValidationException;

namespace NETPCTest.Infrastructure.Pipeline
{
    /// <summary>
    /// Thanks to that class i will be able to
    /// collect all of the Validation erros which i will define via
    /// fluentValdiation package. If any validation erroros occur
    /// they is Thrown my custom exception, which is caught by middleware which wrap
    /// it in correct error structure for api calls and display info to user.
    ///This class that im inheriting is from mediatR package.
    /// </summary>
    /// <typeparam name="TRequest">User sending</typeparam>
    /// <typeparam name="TResponse">Application returning</typeparam>
    public sealed class PipelineValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public PipelineValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
            {
                throw new ValidationException(errorsDictionary);
            }

            return await next();
        }
    }
}
