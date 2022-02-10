namespace Digital_Accept.Domain.Interfaces.Infraestructure
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<int> CommitAsync();
    }
}
