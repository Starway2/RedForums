using RedForums.Data.Common.Models;
using RedForums.Data.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RedForums.Data.Repositories
{
    public class DeletableEntityRepository<TEntity> : Repository<TEntity>, IDeletableEntityRepository<TEntity> where TEntity : class, IDeletableEntity
    {
        public DeletableEntityRepository(ApplicationDbContext context)
               : base(context)
        {
        }
        public override IQueryable<TEntity> All() => base.All().Where(x => !x.IsDeleted);

        public IQueryable<TEntity> AllAsNoTrackingWithDeleted() => AllAsNoTracking().IgnoreQueryFilters();

        public IQueryable<TEntity> AllWithDeleted() => base.All().IgnoreQueryFilters();

        public void HardDelete(TEntity entity) => base.Delete(entity);

        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            Update(entity);
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            Update(entity);
        }
    }
}
