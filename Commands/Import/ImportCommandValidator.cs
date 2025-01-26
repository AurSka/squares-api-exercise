using FluentValidation;

namespace SquarePointsAS.Commands
{
    public class ImportCommandValidator : AbstractValidator<ImportCommand>
    {
        public ImportCommandValidator()
        {
            RuleFor(request => request.x).NotEmpty();
            RuleFor(request => request.x.Length).GreaterThan(0);
            RuleFor(request => request.y).NotEmpty();
            RuleFor(request => request.y.Length).GreaterThan(0);
            RuleFor(request => request.x.Length).Equal(request => request.y.Length);
        }
    }
}
