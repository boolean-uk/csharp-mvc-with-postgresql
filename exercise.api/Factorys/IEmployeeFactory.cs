using exercise.api.DTOs;
using exercise.api.Models;

namespace exercise.api.Factorys
{
    public interface IEmployeeFactory
    {
        Employee FromDTO(EmployeeInputDTO dto);
        void UpdateFromDTO(Employee employee, EmployeeInputDTO dto);
        EmployeeOutputDTO ToDTO(Employee employee);
    }
}
