using exercise.api.Context;
using exercise.api.Data;
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

        public IEnumerable<Department> GetAllDepartments()
        {
            using (var db = new EmployeeContext ())
            {
                return db.Departments.Include(a=> a.Employees).ThenInclude(b => b.Salary).ToList();
            }
            return null;
        }

        public Department GetDepartment(int id)
        {
            Department result;
            using (var db = new EmployeeContext ())
            {
                return db.Departments.FirstOrDefault(a => a.Id == id);
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

        public bool UpdateDepartment(Department department)
        {
            using (var db = new EmployeeContext ())
            {
                db.Departments.Update(department);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteDepartment(int id)
        {
            using (var db = new EmployeeContext ())
            {
                var department = db.Departments.FirstOrDefault(a=>a.Id == id);
                if(department != null)
                {
                    db.Departments.Remove(department);
                    db.SaveChanges();
                        return true;
                }
            }
            return false;
        }

        public IEnumerable<Salary> GetAllSalaries()
        {
            using (var db = new EmployeeContext())
            {
                return db.Salaries.ToList();
            }
            return null;
        }

        public Salary GetSalary(int id)
        {
            Salary result;
            using (var db = new EmployeeContext ())
            {
                return db.Salaries.FirstOrDefault(a=>a.Id == id);
            }
        }

        public bool AddSalary(Salary salary)
        {
            using (var db = new EmployeeContext())
            {
                db.Salaries.Add(salary);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateSalary(Salary salary)
        {
            using (var db = new EmployeeContext ())
            {
                db.Salaries.Update(salary);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteSalary(int id)
        {
            using (var db = new EmployeeContext())
            {
                var salary = db.Salaries.FirstOrDefault(a => a.Id == id);
                if (salary != null)
                {
                    db.Salaries.Remove(salary);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
