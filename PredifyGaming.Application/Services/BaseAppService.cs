using AutoMapper;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;


namespace PredifyGaming.Application.Services
{
    public class BaseAppService<TEntity, TEntityDTO> : IBaseAppService<TEntity, TEntityDTO> 
        where TEntity : class
    {
        private readonly IBaseDomainService<TEntity> _domainService;
        private readonly IMapper _mapper;

        public BaseAppService(IBaseDomainService<TEntity> domainService, IMapper mapper)
        {
            this._domainService = domainService;
            this._mapper = mapper;
        }


        public virtual async Task<TEntity> CreateAsync(TEntityDTO entity)
        {
           var data = await _domainService.CreateAsync(_mapper.Map<TEntity>(entity));
            return data;
        }
        public async Task<TEntity> UpdateAsync(TEntityDTO entity)
        {
            var data = await _domainService.UpdateAsync(_mapper.Map<TEntity>(entity));
            return data;
        }
        public async Task DeleteAsync(long id)
        {
            await _domainService.DeleteAsync(id);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            var entity = await _domainService.GetAllAsync();
            return entity.ToList();
        }
        public async Task<TEntity> GetByIdAsync(long id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            return entity;
        }
    }
}
