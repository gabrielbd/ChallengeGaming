using AutoMapper;
using PredifyGaming.Application.Commands.Games;
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
    public class GamesAppService : BaseAppService<Games, GamesDTO>, IGamesAppService
    {
        public GamesAppService(IBaseDomainService<Games> domainService, IMapper mapper)
            : base(domainService, mapper)
        {
        }

    }
}
