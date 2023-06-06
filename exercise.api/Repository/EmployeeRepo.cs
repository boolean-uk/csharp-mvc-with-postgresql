using exercise.api.DataContext;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Repository
{
    public class EmployeeRepo : iEmployeeRepo
    {
        public EmployeeRepo()
        {

        }
        public Employee AddEmployee(Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return employee;
            }
        }

        public Employee DeleteEmployee(int id)
        {
            using (var db = new EmployeeContext())
            {
                var employee = db.Employees.FirstOrDefault(x => x.Id == id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return employee;
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var db = new EmployeeContext())
            {
                var employee = db.Employees.FirstOrDefault(x => x.Id == id);
                return employee;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                db.Employees.Update(employee);
                db.SaveChanges();
                return employee;
            }
        }
    }
}
