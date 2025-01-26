using MediatR;
using SquarePointsAS.Entities;
using SquarePointsAS.Interfaces;

namespace SquarePointsAS.Commands
{
    public class ImportCommandHandler : IRequestHandler<ImportCommand>
    {
        private readonly IPointRepository pointRepository;
        public ImportCommandHandler (IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public async Task Handle(ImportCommand request, CancellationToken cancellationToken)
        {
            if(request.x.Length != request.y.Length)
            {
                throw new ArgumentException("Both X and Y arrays need to be of the same length!");
            }

            if (request.overwrite)
            {
                await pointRepository.WipePoints(cancellationToken);
            }

            List<SquarePoint> points = new List<SquarePoint>();
            for (int t = 0;  t < request.x.Length; t++)
            {
                var point = await pointRepository.GetByCoords(request.x[t], request.y[t], cancellationToken);
                if (point == null)
                {
                    points.Add(new SquarePoint { X = request.x[t], Y = request.y[t] });
                }
            }

            await pointRepository.AddRangeAsync(points);
        }
    }
}
