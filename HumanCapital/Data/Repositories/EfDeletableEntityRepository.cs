using HumanCapital.Data.Common;

namespace HumanCapital.Data.Repositories
{
    public class EfDeletableEntityRepository<TEntity> : EfRepository<TEntity>, IDeletableEntityRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        public EfDeletableEntityRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task<List<TEntity>> AllAsync(CancellationToken cancellationToken)
        {
            var all = await base.AllAsync(cancellationToken);
            return all.Where(x => !x.IsDeleted).ToList();
        }

        public async Task<List<TEntity>> AllWithDeletedAsync(CancellationToken cancellationToken)
        {
            var all = await base.AllAsync(cancellationToken);
            return all.ToList();
        }

        public override async Task<List<TEntity>> AllAsNoTrackingAsync(CancellationToken cancellationToken)
        {
            var allAsNoTracking = await base.AllAsNoTrackingAsync(cancellationToken);
            return allAsNoTracking.Where(x => !x.IsDeleted).ToList();
        }

        public async Task<List<TEntity>> AllAsNoTrackingWithDeletedAsync(CancellationToken cancellationToken)
        {
            var allAsNoTracking = await base.AllAsNoTrackingAsync(cancellationToken);
            return allAsNoTracking.Where(x => !x.IsDeleted).ToList();

        }

        public override async ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] id)
        {
            var entity = await base.GetByIdAsync(cancellationToken, id);

            if (entity?.IsDeleted ?? false)
            {
                entity = null;
            }

            return entity;
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;

            Update(entity);
        }

        public void HardDelete(TEntity entity)
        {
            base.Delete(entity);
        }

        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;

            Update(entity);
        }
    }
}
