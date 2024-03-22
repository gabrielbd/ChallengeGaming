using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Application.Interfaces
{
    public interface IBaseAppService<TEntity, TEntityDTO>
        where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntityDTO entity);
        Task<TEntity> UpdateAsync(TEntityDTO entity);
        Task DeleteAsync(long id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);

    }
}
