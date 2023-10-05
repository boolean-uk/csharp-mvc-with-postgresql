using exercise.api.DataContext;
using exercise.api.Models;
using System.Security.Policy;

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
                var target = db.Employees.FirstOrDefault(a => a.Id == id);
                if (target != null)
                {
                    db.Remove(target);
                    return true;
                }
            };
            return false;
        }


        public IEnumerable<Employee> GetAllEmployees()
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
            return null;
        }


        public Employee GetEmployee(int id)
        {
            Employee result;
            using (var db = new EmployeeContext())
            {
                result = db.Employees.FirstOrDefault(c => c.Id == id);
            };
            return result;
        }


        public bool UpdateEmployee(Employee employee)
        {
            using (var db = new EmployeeContext())
            {
                var target = db.Employees.FirstOrDefault(c => c.Id == employee.Id);
                if (target != null)
                {
                    db.Employees.Attach(target);
                    target.name = employee.name;
                    target.jobName = employee.jobName;
                    target.salaryGrade = employee.salaryGrade;
                    target.department = employee.department;
                    db.SaveChanges();
                    return true;

                }
            }
            return false;
        }
    }
}

