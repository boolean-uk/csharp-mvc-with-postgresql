using exercise.api.Data;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Repository
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }

        public override IQueryable<Employee> IncludeProperties(IQueryable<Employee> query)
        {
            return query.Include(e => e.Department)
                        .Include(e => e.SalaryGrade);
        }
    }
}