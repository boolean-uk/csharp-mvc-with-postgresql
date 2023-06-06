using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> DeleteEmployee(int id);
        Employee UpdateEmployee(Employee employee, int id);

    }
}
