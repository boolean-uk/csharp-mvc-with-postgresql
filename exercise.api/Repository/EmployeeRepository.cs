using exercise.api.Models;
using exercise.api.DataContext;

namespace exercise.api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee AddEmployee(Employee employee)
        {
            using(var db = new EmployeeContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return employee;
            }
        }

        public IEnumerable<Employee> DeleteEmployee(int id)
        {
            using (var db = new EmployeeContext())
            {
                var employee = db.Employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    return db.Employees.ToList();
                }
                return null;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var db = new EmployeeContext())
            {
                var employee = db.Employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    return employee;
                }
                return null;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using(var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }

        public Employee UpdateEmployee(Employee employee, int id)
        {
            using (var db = new EmployeeContext())
            {
                var employeeToUpdate = db.Employees.Find(id);
                if (employeeToUpdate != null)
                {
                    employeeToUpdate.Id = id;
                    employeeToUpdate.JobName = employee.JobName;
                    employeeToUpdate.SalaryGrade = employee.SalaryGrade;
                    employeeToUpdate.Name = employee.Name;
                    employeeToUpdate.Department = employee.Department;
                    db.Update(employeeToUpdate);
                    db.SaveChanges();
                    return employeeToUpdate;
                }
                return employee;
            }
        }
    }
}
