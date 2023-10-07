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
            }
        }
    }
}

