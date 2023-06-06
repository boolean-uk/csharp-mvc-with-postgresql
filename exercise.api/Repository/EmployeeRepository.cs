using exercise.api.Data;
using exercise.api.Model;

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

        public Employee GetAEmployee(int id)
        {
            Employee result;
            using (var db = new EmployeeContext())
            {
                result = db.Employees.Find(id);
            }
            return result;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                db.Update(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteEmployee(int id)
        {
            using (var db = new EmployeeContext())
            {
                var a = db.Employees.Find(id);
                if (a != null)
                {
                    db.Employees.Remove(a);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
