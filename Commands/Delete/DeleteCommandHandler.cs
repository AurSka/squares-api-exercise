using MediatR;
using SquarePointsAS.Interfaces;

namespace SquarePointsAS.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly IPointRepository pointRepository;
        public DeleteCommandHandler (IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var point = await pointRepository.GetByCoords(request.x, request.y, cancellationToken);

            if (point == null)
            {
                throw new DirectoryNotFoundException();
            }
            else
            {
                await pointRepository.DeleteAsync(point, cancellationToken);
            }
        }
    }
}
