using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
