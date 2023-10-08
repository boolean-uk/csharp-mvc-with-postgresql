using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface IDepartRepo
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartment(int id);
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(int id);
    }
}
