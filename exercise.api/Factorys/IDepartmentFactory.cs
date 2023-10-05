using exercise.api.DTOs;
using exercise.api.Models;

namespace exercise.api.Factorys
{
    public interface IDepartmentFactory
    {
        Department Create(DepartmentDTO dto);
        void UpdateFromDTO(Department existingDepartment, DepartmentDTO dto);
        DepartmentOutputDTO ToDTO(Department department);

    }
}