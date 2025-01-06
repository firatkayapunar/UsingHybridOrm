using AutoMapper;
using UsingHybridOrm.DataAccess.Abstract;
using UsingHybridOrm.DataAccess.Abstract.Resolver;
using UsingHybridOrm.Entities.Concrete;
using UsingHybridOrm.Entities.DTO.Department;
using UsingHybridOrm.Services.Abstract;
using UsingHybridOrm.Services.Validation;
using UsingHybridOrm.Services.Validation.FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace UsingHybridOrm.Services.Concrete
{
    internal class DepartmentService :
                   IDepartmentService
    {
        private readonly IDepartmentRepository _efDepartmentRepository;
        private readonly IDepartmentRepository _dapperDepartmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepositoryResolver departmentDalResolver,
                                 IMapper mapper)
        {
            _efDepartmentRepository = departmentDalResolver.CreateDepartmentRepository(DalKeyEnum.EF);
            _dapperDepartmentRepository = departmentDalResolver.CreateDepartmentRepository(DalKeyEnum.Dapper);
            _mapper = mapper;
        }

        public Result Add(DepartmentCreateDTO departmentCreateDTO)
        {
            try
            {
                var department = _mapper.Map<Department>(departmentCreateDTO);

                ValidationTool.Validate(new DepartmentValidator(), department);

                _efDepartmentRepository.Add(department);

                return Result.SuccessResult("Department successfully added.");
            }
            catch (ValidationException ex)
            {
                return Result.FailureResult("Validation failed.", new List<string> { ex.Message });
            }
            catch (Exception ex)
            {
                return Result.FailureResult("An error occurred while adding the department.", new List<string> { ex.Message });
            }
        }
        public Result Update(DepartmentUpdateDTO departmentUpdateDTO)
        {
            try
            {
                var departmentDTO = Get(departmentUpdateDTO.ID);

                if (departmentDTO == null)
                    return Result.FailureResult("Department not found.",
                        new List<string> { "The department with the given ID does not exist." });

                var department = _mapper.Map<Department>(departmentUpdateDTO);

                ValidationTool.Validate(new DepartmentValidator(), department);

                _efDepartmentRepository.Update(department);

                return Result.SuccessResult("Department successfully updated.");
            }
            catch (ValidationException ex)
            {
                return Result.FailureResult("Validation failed.", new List<string> { ex.Message });
            }
            catch (Exception ex)
            {
                return Result.FailureResult("An error occurred while updating the department.", new List<string> { ex.Message });
            }
        }
        public Result Delete(DepartmentDeleteDTO departmentDeleteDTO)
        {
            try
            {
                var department = _efDepartmentRepository.GetById(departmentDeleteDTO.ID);

                if (department == null)
                    return Result.FailureResult("Department not found.",
                        new List<string> { "The department with the given ID does not exist." });


                _efDepartmentRepository.Delete(department.ID);

                return Result.SuccessResult("Department successfully deleted.");
            }
            catch (Exception ex)
            {
                return Result.FailureResult("An error occurred while deleting the department.", new List<string> { ex.Message });
            }
        }
        public DepartmentDTO Get(int id)
        {
            var department = _efDepartmentRepository.GetById(id);

            return _mapper.Map<DepartmentDTO>(department);
        }
        public List<DepartmentDTO> GetList()
        {
            var departments = _efDepartmentRepository.GetAll();

            foreach (var department in departments)
            {
                department.Name = department.Name.ToUpper();
            }

            return _mapper.Map<List<DepartmentDTO>>(departments);
        }
    }
}
