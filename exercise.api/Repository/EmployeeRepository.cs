using exercise.api.Data;
using exercise.api.Models;

namespace exercise.api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            using(var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }
    }
}
