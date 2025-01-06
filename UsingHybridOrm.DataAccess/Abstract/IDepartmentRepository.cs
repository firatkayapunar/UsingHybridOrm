using UsingHybridOrm.DataAccess.Abstract.Base;
using UsingHybridOrm.Entities.Concrete;

namespace UsingHybridOrm.DataAccess.Abstract
{
    public interface IDepartmentRepository :
                     IRepository<Department>
    { }
}
