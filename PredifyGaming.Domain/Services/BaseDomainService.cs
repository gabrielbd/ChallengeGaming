using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;


namespace PredifyGaming.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
      where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseDomainService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var data = await _repository.CreateAsync(entity);
            return data;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var data = await _repository.UpdateAsync(entity);
            return data;       
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(long id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
