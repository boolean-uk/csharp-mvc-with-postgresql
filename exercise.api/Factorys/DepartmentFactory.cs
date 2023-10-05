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

        public void UpdateFromDTO(Department existingDepartment, DepartmentDTO dto)
        {
            existingDepartment.Name = dto.Name;
            existingDepartment.Location = dto.Location;
        }
    }
}
