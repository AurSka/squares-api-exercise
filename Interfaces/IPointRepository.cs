using SquarePointsAS.Entities;

namespace SquarePointsAS.Interfaces
{
    public interface IPointRepository : IRepository<SquarePoint>
    {
        Task<SquarePoint> GetByCoords(int x, int y, CancellationToken cancellationToken);
        Task<List<SquarePoint>> GetAllPoints(CancellationToken cancellationToken);
        Task WipePoints(CancellationToken cancellationToken);
    }
}
