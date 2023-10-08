using exercise.api.DataContext;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    return db.Employees.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var db = new CompanyContext())
            {
                Employee result = db.Employees.FirstOrDefault(e => e.Id == id);
                return result;
            }
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    db.Employees.Add(employee);
                    int affectedRows = db.SaveChanges();
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    db.Employees.Update(employee);
                    int affectedRows = db.SaveChanges();
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    var employeeToDelete = db.Employees.FirstOrDefault(e => e.Id == id);
                    if (employeeToDelete != null)
                    {
                        db.Employees.Remove(employeeToDelete);
                        int affectedRows = db.SaveChanges();
                        if (affectedRows > 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Salary> GetAllSalaries()
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    return db.Salaries.Include(s => s.Employees).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Salary GetSalary(int id)
        {
            using (var db = new CompanyContext())
            {
                Salary result = db.Salaries.Include(s => s.Employees).FirstOrDefault(s => s.Id == id);
                return result;
            }
        }

        public bool AddSalary(Salary salary)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    db.Salaries.Add(salary);
                    int affectedRows = db.SaveChanges();
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateSalary(Salary salary)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    db.Salaries.Update(salary);
                    int affectedRows = db.SaveChanges();
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteSalary(int id)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    var salaryToDelete = db.Salaries.FirstOrDefault(s => s.Id == id);
                    if (salaryToDelete != null)
                    {
                        db.Salaries.Remove(salaryToDelete);
                        int affectedRows = db.SaveChanges();
                        if (affectedRows > 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    return db.Departments.Include(d => d.Employees).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Department GetDepartment(int id)
        {
            using (var db = new CompanyContext())
            {
                Department result = db.Departments.Include(d => d.Employees).FirstOrDefault(a => a.Id == id);
                return result;
            }
        }

        public bool AddDepartment(Department department)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    db.Departments.Add(department);
                    int affectedRows = db.SaveChanges();
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDepartment(Department department)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    db.Departments.Update(department);
                    int affectedRows = db.SaveChanges();
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDepartment(int id)
        {
            try
            {
                using (var db = new CompanyContext())
                {
                    var departmentToDelete = db.Departments.FirstOrDefault(d => d.Id == id);
                    if (departmentToDelete != null)
                    {
                        db.Departments.Remove(departmentToDelete);
                        int affectedRows = db.SaveChanges();
                        if (affectedRows > 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
