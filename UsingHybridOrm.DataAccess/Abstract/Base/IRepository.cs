using UsingHybridOrm.Entities.Concrete;

namespace UsingHybridOrm.DataAccess.Abstract.Base
{
    public interface IRepository<TEntity> :
                     IQueryRepository<TEntity>,
                     ICommandRepository<TEntity>
                     where TEntity : BaseEntity
    { }
}
