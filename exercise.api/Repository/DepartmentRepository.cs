using exercise.api.Data;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Repository
{
    public class DepartmentRepository : Repository<Department>
    {
        public DepartmentRepository(AppDbContext context) : base(context) { }

        public override IQueryable<Department> IncludeProperties(IQueryable<Department> query)
        {
            return query.Include(d => d.Employees);
        }
    }
}