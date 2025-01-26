using FluentValidation;

namespace SquarePointsAS.Commands
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(request => request.x).NotEmpty();
            RuleFor(request => request.y).NotEmpty();
        }
    }
}
