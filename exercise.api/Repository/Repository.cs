using exercise.api.Data;
using exercise.api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace exercise.api.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntityWithId
    {
        private readonly AppDbContext _context;
        private DbSet<T> entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public virtual IQueryable<T> IncludeProperties(IQueryable<T> query)
        {
            return query;
        }

        public async Task Add(T entity)
        {
            entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var query = entities.AsQueryable();
            query = IncludeProperties(query);
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var query = entities.AsQueryable();
            query = IncludeProperties(query);
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(T entity)
        {
            entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            if (entity != null)
            {
                entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = entities.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
