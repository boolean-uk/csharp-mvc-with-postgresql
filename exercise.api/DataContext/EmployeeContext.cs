using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

    }
}
