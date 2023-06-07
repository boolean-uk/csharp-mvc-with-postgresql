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

        IEnumerable<Salary> GetSalaries();
        Salary GetSalary(int id);
        IEnumerable<Salary> DeleteSalary(int id);

        Salary UpdateSalaryGrade(Salary sal, int id);

        Salary AddSalaryGrade(Salary sal);

    }
}
