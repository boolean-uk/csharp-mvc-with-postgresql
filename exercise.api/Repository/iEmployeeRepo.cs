using exercise.api.Models;

namespace exercise.api.Repository
{
    public interface iEmployeeRepo
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int id);

        IEnumerable<Salary> GetSalaries();
        Salary GetSalary(int id);
        Salary AddSalary(Salary salary);
        Salary UpdateSalary(Salary salary);
        Salary DeleteSalary(int id);

        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int id);
        Department AddDepartment(Department department);
        Department UpdateDepartment(Department department);
        Department DeleteDepartment(int id);


    }
}
