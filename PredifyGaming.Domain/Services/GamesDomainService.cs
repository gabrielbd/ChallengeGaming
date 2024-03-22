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
    public class GamesDomainService : BaseDomainService<Games> , IGamesDomainService
    {
        private readonly IGamesRepository _repository;

        public GamesDomainService(IGamesRepository repository)
            :base(repository) 
        {
            _repository = repository;
        }
    }
}
