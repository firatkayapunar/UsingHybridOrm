using UsingHybridOrm.DataAccess.Abstract;
using UsingHybridOrm.DataAccess.Concrete.EntityFramework.Context;
using UsingHybridOrm.Entities.Concrete;

namespace UsingHybridOrm.DataAccess.Concrete.EntityFramework.Base
{
    public class EfDepartmentRepository :
                 EfBaseRepository<Department, UsingHybridOrmDbContext>,
                 IDepartmentRepository
    {
        private readonly UsingHybridOrmDbContext _context;

        public EfDepartmentRepository(UsingHybridOrmDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
