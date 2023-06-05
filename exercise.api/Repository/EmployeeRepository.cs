using exercise.api.DataContext;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool AddEmployee(Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteEmployee(int id)
        {
            using (var db = new EmployeeContext())
            {
                db.Remove(db.Employees.Find(id));
                db.SaveChanges();
                return true;
            };
            return false;
        }

        public Employee GetEmployee(int id)
        {
            Employee result;
            using (var db = new EmployeeContext())
            {
                result = db.Employees.Find(id);
                db.SaveChanges();
                return result;
            };
            return result;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
            return null;
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                db.Update(employee);
                db.SaveChanges();
                return true;
            };
            return false;
        }
    }
}
