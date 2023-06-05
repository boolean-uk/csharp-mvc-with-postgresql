using exercise.api.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace exercise.api.DataContext
{
    public class EmployeeContext : DbContext
    {
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
        public DbSet<SalaryGrade> SalaryGrades { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
