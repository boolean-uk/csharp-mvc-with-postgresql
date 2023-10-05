using exercise.api.DTOs;
using exercise.api.Models;

namespace exercise.api.Factorys
{
    public class DepartmentFactory : IDepartmentFactory
    {
        public Department Create(DepartmentDTO dto)
        {
            return new Department
            {
                Name = dto.Name,
                Location = dto.Location
            };
        }

        public DepartmentOutputDTO ToDTO(Department department)
        {
            return new DepartmentOutputDTO
            {
                Id = department.Id,
                Name = department.Name,
                Location = department.Location,
                EmployeeNames = department.Employees.Select(e => e.Name).ToList()
            };
        }

        public void UpdateFromDTO(Department existingDepartment, DepartmentDTO dto)
        {
            existingDepartment.Name = dto.Name;
            existingDepartment.Location = dto.Location;
        }
    }
}
