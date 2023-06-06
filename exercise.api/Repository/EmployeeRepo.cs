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
    }
}
