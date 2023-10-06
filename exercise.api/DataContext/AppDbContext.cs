using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SalaryGrade> SalaryGrades { get; set; }
    }
}
