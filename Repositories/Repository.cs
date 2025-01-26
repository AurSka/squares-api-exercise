using Microsoft.EntityFrameworkCore;
using SquarePointsAS.Entities;
using SquarePointsAS.Interfaces;

namespace SquarePointsAS.Repositories
{
    public class Repository<T> : IRepository<T> where T : SquarePoint
    {
        protected readonly Context context;

        public Repository(Context context)
        {
            this.context = context;
        }

        public virtual async Task<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await context.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            context.Set<T>().UpdateRange(entities);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddRangeAsync(entities);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            context.Set<T>().RemoveRange(entities);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
