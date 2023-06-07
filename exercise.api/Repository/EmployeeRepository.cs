using exercise.api.Data;
using exercise.api.Model;
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

        public Employee GetAEmployee(int id)
        {
            Employee result;
            using (var db = new EmployeeContext())
            {
                
                result = db.Employees.Include(e => e.Salary).Include(b => b.Department).FirstOrDefault(x => x.Id == id);
            }
            return result;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.Include(e => e.Salary).Include(b => b.Department).ToList();
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
        public bool AddDepartment(Department department)
        {
            using (var db = new EmployeeContext())
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return true;

            }
            return false;
        }

        public IEnumerable<Department> GetDepartments()
        {
            using (var db = new EmployeeContext())
            {
                return db.Departments.ToList();

            }
        }
        public Department GetADepartment(int id)
        {
            Department result;
            using (var db = new EmployeeContext())
            {

                result = db.Departments.Find(id);
            }
            return result;
        }

        public bool UpdateDepartment(Department department)
        {
            using (var db = new EmployeeContext())
            {
                db.Update(department);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteDepartment(int id)
        {
            using (var db = new EmployeeContext())
            {
                var a = db.Departments.Find(id);
                if (a != null)
                {
                    db.Departments.Remove(a);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool AddSalary(Salary salary)
        {
            using (var db= new EmployeeContext())
            {
                db.Salaries.Add(salary);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Salary> GetSalaries() 
        {
            using(var db = new EmployeeContext())
            {
                return db.Salaries.ToList();
            }
        }

        public Salary GetASalary(int id)
        {
            Salary result;
            using (var db = new EmployeeContext())
            {

                result = db.Salaries.Find(id);
            }
            return result;
        }

        public bool UpdateASalary(Salary salary)
        {
            using (var db = new EmployeeContext())
            {
                db.Update(salary);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSalary(int id)
        {
            using (var db = new EmployeeContext())
            {
                var a = db.Salaries.Find(id);
                if (a != null)
                {
                    db.Salaries.Remove(a);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
