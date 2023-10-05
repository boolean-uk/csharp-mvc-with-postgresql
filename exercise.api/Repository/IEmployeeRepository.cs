using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(int id);
    }
}
