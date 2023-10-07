using exercise.api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace exercise.api.DataContext
{
    public class EmployeeContext : DbContext
    {

        private string connectionString;
        public EmployeeContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }


        public DbSet<Employee> Employees { get; set; }

    }
}
