using System.Linq.Expressions;

namespace exercise.api.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes);

    }
}
