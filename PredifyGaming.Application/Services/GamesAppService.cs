using AutoMapper;
using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;

namespace PredifyGaming.Application.Services
{
    public class GamesAppService : BaseAppService<Games>, IGamesAppService
    {
        private readonly IGamesDomainService _domain;
        private readonly IMapper _mapper;
        public GamesAppService(IBaseDomainService<Games> domainService, IGamesDomainService domain, IMapper mapper)
            : base(domainService, mapper)
        {
            _mapper = mapper;
            _domain = domain;
        }

        public async Task<GameDTO> CreateGameAsync(CreateGameCommand command)
        {
            var map = _mapper.Map<Games>(command);
            var addGameResult = await _domain.CreateAsync(map);

            var mapResult = _mapper.Map<GameDTO>(addGameResult);

            return mapResult;
        }
    }
}
