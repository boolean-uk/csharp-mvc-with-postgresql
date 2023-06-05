using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}
