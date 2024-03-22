using AutoMapper;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Application.Services
{
    public class PlayersAppService : BaseAppService<Players, PlayersDTO>, IPlayersAppService
    {
        public PlayersAppService(IBaseDomainService<Players> domainService , IMapper mapper)
            : base(domainService, mapper)
        {
        }

    }
}
