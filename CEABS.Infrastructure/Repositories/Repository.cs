using CEABS.Domain.Repository;
using CEABS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CEABS.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly CeabsContext _context;

        public Repository(CeabsContext context) => _context = context;

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public async Task DeleteAsync(T entity) => _context.Set<T>().Remove(entity);

        public async Task UpdateAsync(T entity) => _context.Set<T>().Update(entity);
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null) => expression == null
            ? await _context.Set<T>().ToListAsync()
            : await _context.Set<T>().Where(expression).ToListAsync();

        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> Get(Expression<Func<T, bool>> expression = null) => await _context.Set<T>().Where(expression).FirstOrDefaultAsync();
    }
}
