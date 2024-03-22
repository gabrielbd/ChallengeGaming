using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Application.Interfaces
{
    public interface IPlayersAppService : IBaseAppService<Players , PlayersDTO>
    {
    }
}
