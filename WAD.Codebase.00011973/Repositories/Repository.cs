using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WAD.Codebase._00011973.Data;
using WAD.Codebase._00011973.Interfaces;

namespace WAD.Codebase._00011973.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly JobBoardContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(JobBoardContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
