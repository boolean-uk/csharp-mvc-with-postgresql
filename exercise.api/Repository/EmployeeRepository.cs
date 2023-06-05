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

        public IEnumerable<Employee> GetEmployees()
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }
    }
}
