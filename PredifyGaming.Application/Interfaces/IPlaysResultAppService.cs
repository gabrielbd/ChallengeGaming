using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Application.Interfaces
{
    public interface IPlaysResultAppService : IBaseAppService<PlaysResult , PlaysResultDTO>
    {
        Task<List<PlaysResultDTO>> GetAllByGameAsync(long idGame);
        Task<List<PlaysResultDTO>> GetAllByPlayerAsync(long idPlayer);
        Task<string> GameResultFormat(PlaysResult gameResult);
    }
}
