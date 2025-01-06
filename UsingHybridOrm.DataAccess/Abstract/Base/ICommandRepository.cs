using UsingHybridOrm.Entities.Concrete;

namespace UsingHybridOrm.DataAccess.Abstract.Base
{
    public interface ICommandRepository<TEntity>
                     where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
