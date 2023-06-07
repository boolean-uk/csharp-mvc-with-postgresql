using exercise.api.DataContext;
using exercise.api.Models;

namespace exercise.api.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        //adds employee
        public Employee AddEmployee(Employee employee)
        {
            using(var db = new EmployeeContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return employee;
            }
        }

        public Salary AddSalaryGrade(Salary sal)
        {
            using (var db = new EmployeeContext())
            {
                db.Salary.Add(sal);
                db.SaveChanges();
                return sal;
            }
        }

        //deletes employee with the given id

        public IEnumerable<Employee> DeleteEmployee(int id)
        {
            using(var db = new EmployeeContext())
            {
                var deletedEmploye = db.Employees.FirstOrDefault(x => x.Id == id);
                if (deletedEmploye != null)
                {
                    db.Remove(deletedEmploye);
                    db.SaveChanges();
                    return db.Employees.ToList();
                }
                return null;

            }
        }

        public IEnumerable<Salary> DeleteSalary(int id)
        {
            using (var db = new EmployeeContext())
            {
                var salaryDelete = db.Salary.FirstOrDefault(x => x.Id == id);
                if (salaryDelete != null)
                {
                    db.Remove(salaryDelete);
                    db.SaveChanges();
                    return db.Salary.ToList();
                }
                return null;

            }
        }

        //gets all employees

        public IEnumerable<Employee> GetAllEmployees()
        {
            using(var db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }

        //gets employee with the given id

        public Employee GetEmployee(int id)
        {
            using( var db = new EmployeeContext())
            {
                var employee = db.Employees.FirstOrDefault( x => x.Id == id);
                if(employee != null)
                {
                    return employee;
                }
                return null;
            }
        }

        public IEnumerable<Salary> GetSalaries()
        {
            using (var db = new EmployeeContext())
            {
                return db.Salary.ToList();
            }
        }

        public Salary GetSalary(int id)
        {
            using (var db = new EmployeeContext())
            {
                var salary = db.Salary.FirstOrDefault(x => x.Id == id);
                if (salary != null)
                {
                    return salary;
                }
                return null;
            }
        }

        //updates an  employee with the given id

        public Employee UpdateEmployee(Employee employee, int id)
        {
            using( var db = new EmployeeContext())
            {
                var empl = db.Employees.Find(id);
                if (empl != null)
                {
                    empl.jobName = employee.jobName;
                    empl.Name = employee.Name;
                    empl.salaryGrade = employee.salaryGrade;
                    empl.department = employee.department;
                    empl.Id = id;
                    db.Update(empl);
                    db.SaveChanges ();
                    return empl;
                }
                return empl;
            }
        }

        public Salary UpdateSalaryGrade(Salary salary, int id)
        {
            using (var db = new EmployeeContext())
            {
                var sal = db.Salary.Find(id);
                if (sal != null)
                {
                    sal.minSalary = salary.minSalary;
                    sal.maxSalary = salary.maxSalary;
                    sal.grade = salary.grade;
                    sal.Id = salary.Id;
                    db.Update(sal);
                    db.SaveChanges();
                    return sal;
                }
                return sal;
            }

        }
    }
}
