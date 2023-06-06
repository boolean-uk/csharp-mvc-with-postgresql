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

        public Department AddDepartment(Department department)
        {
            using (var db = new EmployeeContext())
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return department;
            }
        }

        public Department DeleteDepartment(int id)
        {
            using (var db = new EmployeeContext())
            {
                var department = db.Departments.FirstOrDefault(x => x.Id == id);
                db.Departments.Remove(department);
                db.SaveChanges();
                return department;
            }
        }

        public Department GetDepartment(int id)
        {
            using (var db = new EmployeeContext())
            {
                var department = db.Departments.FirstOrDefault(x => x.Id == id);
                return department;
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            using (var db = new EmployeeContext())
            {
                return db.Departments.ToList();
            }
        }

        public Department UpdateDepartment(Department department)
        {
            using (var db = new EmployeeContext())
            {
                db.Departments.Update(department);
                db.SaveChanges();
                return department;
            }
        }
        public Salary AddSalary(Salary salary)
        {
            using (var db = new EmployeeContext())
            {
                db.Salaries.Add(salary);
                db.SaveChanges();
                return salary;
            }
        }

        public Salary DeleteSalary(int id)
        {
            using (var db = new EmployeeContext())
            {
                var salary = db.Salaries.FirstOrDefault(x => x.Id == id);
                db.Salaries.Remove(salary);
                db.SaveChanges();
                return salary;
            }
        }

        public Salary GetSalary(int id)
        {
            using (var db = new EmployeeContext())
            {
                var salary = db.Salaries.FirstOrDefault(x => x.Id == id);
                return salary;
            }
        }

        public IEnumerable<Salary> GetSalaries()
        {
            using (var db = new EmployeeContext())
            {
                return db.Salaries.ToList();
            }
        }

        public Salary UpdateSalary(Salary salary)
        {
            using (var db = new EmployeeContext())
            {
                db.Salaries.Update(salary);
                db.SaveChanges();
                return salary;
            }
        }

    }
}
