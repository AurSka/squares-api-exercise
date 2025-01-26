using SquarePointsAS.Entities;

namespace SquarePointsAS.Interfaces
{
    public interface IRepository<T> where T : SquarePoint
    {
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
