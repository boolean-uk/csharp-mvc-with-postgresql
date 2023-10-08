using exercise.api.Models;
using System;
using System.Runtime.ConstrainedExecution;

namespace exercise.api.DataContext
{
    public static class Seeder
    {
        public static void Seed(this WebApplication app)
        {
            using (var db = new EmployeeContext())
            {
                if (!db.Employees.Any())
                {
                    db.Employees.Add(new Employee() { name = "Nigel", jobName = "Developer", salaryGrade = "A++", department = "Boolean" });
                    db.Employees.Add(new Employee() { name = "Dave", jobName = "Developer", salaryGrade = "A++", department = "Boolean" });
                    db.Employees.Add(new Employee() { name = "Bob", jobName = "Developer", salaryGrade = "B++", department = "Boolean" });
                    db.SaveChanges();
                }

                db.SaveChanges();

                if (!db.Salaries.Any())
                {
                    db.Salaries.Add(new Salary() { grade = "A++", minSalary = 3000, maxSalary = 5000 });
                    db.Salaries.Add(new Salary() { grade = "A++", minSalary = 3000, maxSalary = 5000 });
                    db.Salaries.Add(new Salary() { grade = "B++", minSalary = 1500, maxSalary = 2500 });
                    db.SaveChanges();
                }

                db.SaveChanges();

                if (!db.Departments.Any())
                {
                    db.Departments.Add(new Department() { name = "C#", location = "London" });
                    db.Departments.Add(new Department() { name = "Java", location = "Pitsburg" });
                    db.Departments.Add(new Department() { name = "React", location = "Bournemouth" });
                    db.SaveChanges();
                }

                db.SaveChanges();
            }

        }
    }
}

