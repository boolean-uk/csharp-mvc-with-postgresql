using exercise.api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace exercise.api.DataContext
{
    public class EmployeeContext : DbContext
    {

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Employee");


        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(m => new { m.Id }); //used when the class doesn't meet EF naming convention.. (ok it does in this case ID but if it was something like AuthorReferenceNumber etc..

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
