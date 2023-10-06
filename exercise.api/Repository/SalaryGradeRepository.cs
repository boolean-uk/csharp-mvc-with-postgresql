using exercise.api.Data;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Repository
{
    public class SalaryGradeRepository : Repository<SalaryGrade>
    {
        public SalaryGradeRepository(AppDbContext context) : base(context) { }

        public override IQueryable<SalaryGrade> IncludeProperties(IQueryable<SalaryGrade> query)
        {
            return query.Include(sg => sg.Employees);
        }
    }
}