using exercise.api.Data;
using exercise.api.Model;

namespace exercise.api.Repository
{
    public interface IEmployeeRepository
    {
       bool AddEmployee(Employee employee);
       IEnumerable<Employee> GetEmployees();
       Employee GetAEmployee(int id);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);

    }
}
