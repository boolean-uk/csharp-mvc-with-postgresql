using exercise.api.DTOs;
using exercise.api.Models;

namespace exercise.api.Factorys
{
    public class EmployeeFactory : Factory<Employee, EmployeeInputDTO, EmployeeOutputDTO>
    {
        public override Employee FromDTO(EmployeeInputDTO dto)
        {
            return new Employee
            {
                Name = dto.Name,
                JobName = dto.JobName,
                SalaryGradeId = dto.SalaryGradeId,
                DepartmentId = dto.DepartmentId
            };
        }

        public override EmployeeOutputDTO ToDTO(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee is null");
            }
            return new EmployeeOutputDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                JobName = employee.JobName,
                SalaryGrade = employee.SalaryGrade?.Grade,
                DepartmentName = employee.Department?.Name
            };
        }

        public override void UpdateFromDTO(Employee employee, EmployeeInputDTO dto)
        {
            employee.Name = dto.Name;
            employee.JobName = dto.JobName;
            employee.SalaryGradeId = dto.SalaryGradeId;
            employee.DepartmentId = dto.DepartmentId;
        }
    }
}