using FluentValidation;
using MediatR;

namespace Application.Behaviours
{
    // IPipeLineBahavior allows us to excute some tasks before or after the request is handeld
    // in this case we are using it to validate the request
    // TRequest is the request type and TResponse is the response type

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        // IValidator is a FluentValidation interface that defines a validator for a specific type
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Check if there are any validators for the request type
            // if there are create a validation context and validate the request
            if (_validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                // Task.WhenAll is used to execute multiple tasks in parallel
                // in this case we are executing all the validators in parallel
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                    throw new Exceptions.ValidationException(failures);
            }
            return await next();
        }
    }
}