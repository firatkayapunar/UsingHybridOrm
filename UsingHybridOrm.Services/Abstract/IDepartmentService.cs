using UsingHybridOrm.Entities.DTO.Department;

namespace UsingHybridOrm.Services.Abstract
{
    public interface IDepartmentService
    {
        Result Add(DepartmentCreateDTO department);
        Result Update(DepartmentUpdateDTO department);
        Result Delete(DepartmentDeleteDTO department);
        DepartmentDTO Get(int id); 
        List<DepartmentDTO> GetList();
    }
}
