using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface ICompanyRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);


        IEnumerable<Salary> GetAllSalaries();
        Salary GetSalary(int id);
        bool AddSalary(Salary salary);
        bool UpdateSalary(Salary salary);
        bool DeleteSalary(int id);


        IEnumerable<Department> GetAllDepartments();
        Department GetDepartment(int id);
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(int id);
    }
}