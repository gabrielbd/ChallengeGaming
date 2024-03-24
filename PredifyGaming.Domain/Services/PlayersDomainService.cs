using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;


namespace PredifyGaming.Domain.Services
{
    public class PlayersDomainService : BaseDomainService<Players> , IPlayersDomainService
    {
        private readonly IUnitOfWork<Players> _unitOfWork;

        public PlayersDomainService(IUnitOfWork<Players> unitOfWork)
            : base(unitOfWork)  
        {
            _unitOfWork = unitOfWork;
        }
    }
}
