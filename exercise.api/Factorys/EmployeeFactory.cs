using exercise.api.DTOs;
using exercise.api.Models;

namespace exercise.api.Factorys
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee FromDTO(EmployeeInputDTO dto)
        {
            return new Employee
            {
                Name = dto.Name,
                JobName = dto.JobName,
                SalaryGrade = dto.SalaryGrade,
                DepartmentId = dto.DepartmentId
            };
        }

        public EmployeeOutputDTO ToDTO(Employee employee)
        {
            return new EmployeeOutputDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                JobName = employee.JobName,
                SalaryGrade = employee.SalaryGrade,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department.Name
            };
        }

        public void UpdateFromDTO(Employee employee, EmployeeInputDTO dto)
        {
            employee.Name = dto.Name;
            employee.JobName = dto.JobName;
            employee.SalaryGrade = dto.SalaryGrade;
            employee.DepartmentId = dto.DepartmentId;
        }
    }
}