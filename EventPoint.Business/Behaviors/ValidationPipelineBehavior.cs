using FluentValidation;
using MediatR;

namespace EventPoint.Business.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators.Select(v => v.Validate(context))
                .SelectMany(x => x.Errors).Where(vFailure => vFailure != null).Distinct().ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
                //return 
            }
            return await next();
        }
    }
}