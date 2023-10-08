using exercise.api.DataContext;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq.Expressions;

namespace exercise.api.Repository
{
    public class SalaryRepo : ISalaryRepo
    {
        public bool AddSalary(Salary salary)
        {
            using(var db = new EmployeeContext())
            {
                db.Salaries.Add(salary);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSalary(int id)
        {
            using(var db = new EmployeeContext())
            {
                var target = db.Salaries.FirstOrDefault(s => s.Id == id);
                if(target != null)
                {
                    db.Remove(target);
                    db.SaveChanges();
                    return true;
                };
                return false;
            }
        }

        public IEnumerable<Salary> GetAllSalaryGrades()
        {
            using(var db = new EmployeeContext())
            {
                return db.Salaries.ToList();
            }
            return null;
        }

        public Salary GetSalary(int id)
        {
            Salary result;
            using (var db = new EmployeeContext())
            {
                result = db.Salaries.FirstOrDefault(s => s.Id == id);
            };
            return result;
        }

        public bool UpdateSalary(Salary salary)
        {
            using (var db = new EmployeeContext())
            {
                var target = db.Salaries.FirstOrDefault(c => c.Id == salary.Id);
                if (target != null)
                {
                    db.Salaries.Attach(target);
                    target.grade = salary.grade;
                    target.minSalary = salary.minSalary;
                    target.maxSalary = salary.maxSalary;
                    db.SaveChanges();
                    return true;

                }
            }
            return false;
        }
    }
}
