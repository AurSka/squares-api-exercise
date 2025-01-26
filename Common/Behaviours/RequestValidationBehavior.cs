using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SquarePointsAS
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = new List<ValidationFailure>();
            foreach (var validator in validators)
            {
                var validationResult = await validator.ValidateAsync(context, cancellationToken);
                var validatonErrors = validationResult.Errors.Where(x => x != null).ToList();
                failures.AddRange(validatonErrors);
            }

            if (failures.Count != 0)
            {
                throw new Exception("One or more validation failures have occurred.");
            }

            return await next();
        }
    }
}
