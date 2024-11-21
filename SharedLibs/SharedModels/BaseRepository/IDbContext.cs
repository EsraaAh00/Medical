using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedModels.Models;

namespace SharedModels.BaseRepository
{
    public interface IDbContext
    {

        IModel Model { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        Task<List<LogModel?>?> GetRecordLog(string? entityName, int? recordId, string logTable, int? transactionId);
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;

        EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
      where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class;
    }
}