namespace UsingHybridOrm.DataAccess.Abstract.Resolver
{
    public interface IDepartmentRepositoryResolver
    {
        IDepartmentRepository CreateDepartmentRepository(DalKeyEnum dalKeyEnum);
    }
}
