using exercise.api.Context;
using exercise.api.Data;
using exercise.api.Models;

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
                var employee = db.Employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Employee GetEmployee(int id)
        {
            Employee result;
            using (var db = new EmployeeContext())
            {
                return db.Employees.FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using(var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                db.Employees.Update(employee);
                db.SaveChanges() ;
                return true;
            }
        }
    }
}
