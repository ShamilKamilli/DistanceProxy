using FluentValidation;
using MediatR;

namespace DistanceProxy.Common.Validators
{
    public class ValidatorPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidatorPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationContext = new ValidationContext<TRequest>(request);
            var validationResponse = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(validationContext)));

            var validationErrors = validationResponse.Where(x => x.Errors.Any())
                .SelectMany(x => x.Errors)
                .ToList();

            if (validationErrors.Any())
                throw new ValidationException(validationErrors);

            return await next();
        }
    }
}
