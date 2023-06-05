using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);

        IEnumerable<Department> GetAllDepartments();
        Department GetDepartment(int id);
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(int id);

    }
}
