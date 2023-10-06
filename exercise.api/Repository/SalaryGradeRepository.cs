using exercise.api.Data;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Repository
{
    public class SalaryGradeRepository : ISalaryGradeRepository
    {
        private readonly AppDbContext _context;
        public SalaryGradeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(SalaryGrade salaryGrade)
        {
            _context.SalaryGrades.Add(salaryGrade);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SalaryGrade>> GetAll()
        {
            return await _context.SalaryGrades
                .Include(sg => sg.Employees)
                .ToListAsync();
        }

        public async Task<SalaryGrade> GetById(int id)
        {
            return await _context.SalaryGrades
                .Include(sg => sg.Employees)
                .FirstOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task Update(SalaryGrade salaryGrade)
        {
            _context.Entry(salaryGrade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var salaryGrade = await _context.SalaryGrades.FindAsync(id);
            if (salaryGrade != null)
            {
                _context.SalaryGrades.Remove(salaryGrade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
