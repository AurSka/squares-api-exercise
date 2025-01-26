using Microsoft.EntityFrameworkCore;
using SquarePointsAS.Entities;
using SquarePointsAS.Interfaces;

namespace SquarePointsAS.Repositories
{
    public class PointRepository : Repository<SquarePoint>, IPointRepository
    {
        public PointRepository(Context context) : base(context)
        {
        }

        /// <summary>
        /// Returns a point if one matches the X and Y coordinate specified.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public async Task<SquarePoint> GetByCoords(int x, int y, CancellationToken cancellationToken)
        {
            return await context.Points
                .Where(point => point.X == x && point.Y == y)
                .FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Returns all points, ordered by X, then by Y.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public async Task<List<SquarePoint>> GetAllPoints(CancellationToken cancellationToken)
        {
            return await context.Points.OrderBy(point => point.X).ThenBy(point => point.Y).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Clears the table of any points
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public async Task WipePoints(CancellationToken cancellationToken)
        {
            await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [Points]");
        }
    }
}
