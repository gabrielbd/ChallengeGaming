using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;

namespace PredifyGaming.Domain.Services
{
    public class GamesDomainService : BaseDomainService<Games> , IGamesDomainService
    {
        private readonly IUnitOfWork<Games> _unitOfWork;
        public GamesDomainService(IUnitOfWork<Games> unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
