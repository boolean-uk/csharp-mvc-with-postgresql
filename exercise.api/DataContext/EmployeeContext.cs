using exercise.api.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace exercise.api.DataContext
{
    public class EmployeeContext : DbContext
    {
        // create the connection with the database with specific config string and create the dbset (table) for Employees
        private static string GetConnectionString()
        {
            string jsonSettings = File.ReadAllText("appsettings.json");
            JObject configuration = JObject.Parse(jsonSettings);
            return configuration["ConnectionStrings"]["DefaultConnectionString"].ToString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetConnectionString());

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salary { get; set; }

    }
}
