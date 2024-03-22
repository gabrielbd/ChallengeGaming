namespace PredifyGaming.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity> : IDisposable
         where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(long id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
    }
}
