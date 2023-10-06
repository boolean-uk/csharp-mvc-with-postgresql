using Bogus;
using exercise.api.Models;

namespace exercise.api.Data
{
    //used Bogus as seeder library https://github.com/bchavez/Bogus
    public class Seeder
    {
        private readonly AppDbContext _context;

        public Seeder(AppDbContext context)
        {
            _context = context;
        }

        public void SeedData(int numberOfDepartments = 10, int employeesPerDepartment = 10)
        {
            // Ensure the database is created
            _context.Database.EnsureCreated();

            if (!_context.Departments.Any())
            {
                // Seed departments first
                var departmentFaker = new Faker<Department>()
                    .RuleFor(d => d.Name, f => f.Commerce.Department())
                    .RuleFor(d => d.Location, f => f.Address.City());

                var departments = departmentFaker.Generate(numberOfDepartments);
                _context.Departments.AddRange(departments);
                _context.SaveChanges();
            }
            // then seed the salaries
            if (!_context.SalaryGrades.Any())
            {
                var salaryGrades = Enumerable.Range(1, 10).Select(i => new SalaryGrade
                {
                    Grade = i.ToString(),
                    MinSalary = i * 3000,
                    MaxSalary = i * 3000 + 4000
                }).ToList();

                _context.SalaryGrades.AddRange(salaryGrades);
                _context.SaveChanges();
            }

            if (!_context.Employees.Any())
            {
                // now seed employees and associate them with the departments and salarygrades
                var departmentsInDb = _context.Departments.ToList();
                var salaryGradesInDb = _context.SalaryGrades.ToList();

                var employeeFaker = new Faker<Employee>()
                    .RuleFor(e => e.Name, f => f.Name.FullName())
                    .RuleFor(e => e.JobName, f => f.Name.JobTitle())
                    .RuleFor(e => e.SalaryGradeId, f => f.PickRandom(salaryGradesInDb).Id)
                    .RuleFor(e => e.DepartmentId, f => f.PickRandom(departmentsInDb).Id);

                var employees = employeeFaker.Generate(numberOfDepartments * employeesPerDepartment);
                _context.Employees.AddRange(employees);
                _context.SaveChanges();
            }
        }
    }
}