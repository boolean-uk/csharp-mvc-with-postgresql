using Bogus;
using exercise.api.Models;

namespace exercise.api.Data
{
    //used Bogus as seeder library https://github.com/bchavez/Bogus
    public class Seeder
    {
        private readonly EmployeeContext _context;

        public Seeder(EmployeeContext context)
        {
            _context = context;
        }

        public void SeedEmployees(int numberOfEmployees = 100) //100 sounds enough for this exercise
        {
            // first ensure database exists
            _context.Database.EnsureCreated();

            // If the database already contains entries, no seeding is required
            if (_context.Employees.Any())
            {
                return;
            }

            // then use Bogus to generate entries
            var faker = new Faker<Employee>()
                .RuleFor(e => e.Name, f => f.Name.FullName())
                .RuleFor(e => e.JobName, f => f.Name.JobTitle())
                .RuleFor(e => e.SalaryGrade, f => f.Random.Int(1, 10).ToString())
                .RuleFor(e => e.Department, f => f.Commerce.Department());

            var employees = faker.Generate(numberOfEmployees);

            // add to dbset and save changes
            _context.Employees.AddRange(employees);
            _context.SaveChanges();
        }
    }
}
