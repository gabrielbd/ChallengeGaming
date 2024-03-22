using PredifyGaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Domain.Interfaces.Services
{
    public interface IPlaysResultDomainService : IBaseDomainService<PlaysResult>
    {
        Task<List<PlaysResult>> GetAllByGameAsync(long idGame);
        Task<List<PlaysResult>> GetAllByPlayerAsync(long idPlayer);
    }
}
