using HumanCapital.Data.Common;

namespace HumanCapital.Data.Repositories
{
    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        Task<List<TEntity>> AllWithDeletedAsync(CancellationToken cancellationToken);

        Task<List<TEntity>> AllAsNoTrackingWithDeletedAsync(CancellationToken cancellationToken);

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
