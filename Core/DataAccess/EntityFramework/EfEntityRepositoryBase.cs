using Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity t)
        {
            using TContext c = new TContext();
            var addedEntity = c.Entry(t);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public void Delete(TEntity t)
        {
            using TContext c = new TContext();
            var deletedEntity = c.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext c = new TContext();
            return c.Set<TEntity>().SingleOrDefault(filter);

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext c = new TContext();
            return filter == null
                ? c.Set<TEntity>().ToList()
                : c.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity t)
        {
            using TContext c = new TContext();
            var updatedEntity = c.Entry(t);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
