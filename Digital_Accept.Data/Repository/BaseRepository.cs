using Digital_Accept.Data.Context;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Digital_Accept.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly DbSet<T> _dbSet;


        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = applicationDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : T
        {
            _dbSet.Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : T
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : T
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
