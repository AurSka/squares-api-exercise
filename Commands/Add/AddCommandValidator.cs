using FluentValidation;

namespace SquarePointsAS.Commands
{
    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        public AddCommandValidator()
        {
            RuleFor(request => request.x).NotEmpty();
            RuleFor(request => request.y).NotEmpty();
        }
    }
}
