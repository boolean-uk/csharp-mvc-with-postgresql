using exercise.api.Data;
using exercise.api.Model;

namespace exercise.api.Repository
{
    public interface IEmployeeRepository
    {
        //Employee
        bool AddEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        Employee GetAEmployee(int id);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);

        //Department
        bool AddDepartment(Department department);
        IEnumerable<Department> GetDepartments();
        Department GetADepartment(int id);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(int id);
        
        //Salary
        bool AddSalary(Salary salary);
        IEnumerable<Salary> GetSalaries();
        Salary GetASalary(int id);
        bool UpdateASalary(Salary salary);
        bool DeleteSalary(int id);

    }
}
