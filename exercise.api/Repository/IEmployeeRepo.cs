using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        IEnumerable<Employee> DeleteEmployee(int id);

        Employee UpdateEmployee(Employee employee,int id);

        Employee AddEmployee(Employee employee);

    }
}
