using exercise.api.Data;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.api.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments
                .Include(d => d.Employees)
                .ToListAsync();
        }
        public async Task<Department> GetById(int id)
        {
            return await _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task Update(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
