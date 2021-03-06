using System.Linq.Expressions;

namespace Digital_Accept.Domain.Interfaces.Infraestructure
{
    public interface IBaseRepository <T> 
    {
        void Add<TEntity>(TEntity entity) where TEntity : T;

        void Update<TEntity>(TEntity entity) where TEntity : T;

        void Delete<TEntity>(TEntity entity) where TEntity : T;

        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(long id);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
