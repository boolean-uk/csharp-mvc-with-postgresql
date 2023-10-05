using exercise.api.Models;

namespace exercise.api.Repositoy
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task Add(Department department);
        Task Update(Department department);
        Task Delete(int id);
    }
}
