using MediatR;
using SquarePointsAS.Entities;
using SquarePointsAS.Interfaces;

namespace SquarePointsAS.Commands
{
    public class AddCommandHandler : IRequestHandler<AddCommand>
    {
        private readonly IPointRepository pointRepository;
        public AddCommandHandler (IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public async Task Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var point = await pointRepository.GetByCoords(request.x, request.y, cancellationToken);

            if (point == null)
            {
                await pointRepository.AddAsync(new SquarePoint { X = request.x, Y = request.y });
            }
            else
            {
                throw new Exception("Point already exists!");
            }
        }
    }
}
