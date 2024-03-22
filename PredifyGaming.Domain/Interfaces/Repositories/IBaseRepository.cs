

namespace PredifyGaming.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
       where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(long id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
    }
}
