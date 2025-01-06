using UsingHybridOrm.DataAccess.Abstract;
using UsingHybridOrm.Entities.Concrete;
using System.Data;

namespace UsingHybridOrm.DataAccess.Concrete.Dapper
{
    public class DapperDepartmentRepository :
                 DapperBaseRepository<Department>,
                 IDepartmentRepository
    {

        public DapperDepartmentRepository(IDbConnection dbConnection) : base(dbConnection)
        { }
    }
}
