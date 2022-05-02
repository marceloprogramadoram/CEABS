using System.Linq.Expressions;

namespace CEABS.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetById(int id);

        Task<T> Get(Expression<Func<T, bool>> expression = null);


    }
}
