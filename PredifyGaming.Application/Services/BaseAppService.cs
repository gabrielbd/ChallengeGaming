using AutoMapper;
using MediatR;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;


namespace PredifyGaming.Application.Services
{
    public class BaseAppService<TEntity> : IBaseAppService<TEntity> 
        where TEntity : class
    {
        private readonly IBaseDomainService<TEntity> _domainService;
        private readonly IMapper _mapper;

        public BaseAppService(IBaseDomainService<TEntity> domainService, IMapper mapper)
        {
            this._domainService = domainService;
            this._mapper = mapper;
        }


        public async Task<TEntity> CreateAsync(TEntity entity)
        {
           var data = await _domainService.CreateAsync(entity);
            return data;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var data = await _domainService.UpdateAsync(entity);
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
