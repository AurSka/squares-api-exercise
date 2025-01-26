using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SquarePointsAS.Entities;

namespace SquarePointsAS
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public DbSet<SquarePoint> Points { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Put in your own SQL server connection string here! 
            optionsBuilder.UseSqlServer(
                @"Server=server;Database=db;ConnectRetryCount=1;TrustServerCertificate=true;User=sa;Password=square");
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
