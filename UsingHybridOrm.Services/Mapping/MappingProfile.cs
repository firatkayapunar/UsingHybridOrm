using AutoMapper;
using UsingHybridOrm.Entities.Concrete;
using UsingHybridOrm.Entities.DTO.Department;

namespace UsingHybridOrm.Services.Mapping
{
    internal class MappingProfile :
                   Profile
    {
        public MappingProfile()
        {
            CreateMap<DepartmentCreateDTO, Department>();
            CreateMap<DepartmentUpdateDTO, Department>();
            CreateMap<DepartmentDeleteDTO, Department>();
            CreateMap<Department, DepartmentDTO>();
        }
    }
}
