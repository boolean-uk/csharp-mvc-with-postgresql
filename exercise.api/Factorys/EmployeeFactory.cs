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
                Department = dto.Department
            };
        }

        public void UpdateFromDTO(Employee employee, EmployeeInputDTO dto)
        {
            employee.Name = dto.Name;
            employee.JobName = dto.JobName;
            employee.SalaryGrade = dto.SalaryGrade;
            employee.Department = dto.Department;
        }
    }
}