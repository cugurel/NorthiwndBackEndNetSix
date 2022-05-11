using System.Linq.Expressions;

namespace Core.Abstract
{
    public interface IEntityRepository<Entity> where Entity : class, IEntity, new()
    {
        List<Entity> GetAll(Expression<Func<Entity, bool>>? filter = null);
        Entity Get(Expression<Func<Entity, bool>> filter);
        void Add(Entity t);
        void Update(Entity t);
        void Delete(Entity t);
    }
}
