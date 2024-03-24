using AutoMapper;
using FluentValidation;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;

namespace PredifyGaming.Application.Services
{
    public class PlayersAppService : BaseAppService<Players>, IPlayersAppService
    {
        private readonly IPlayersDomainService _domain;
        private readonly IMapper _mapper;
        public PlayersAppService(IBaseDomainService<Players> domainService , IPlayersDomainService domain , IMapper mapper)
            : base(domainService, mapper)
        {
            _mapper = mapper;
            _domain = domain;
        }

        public async Task<PlayerDTO> CreatePlayerAsync(CreatePlayerCommand command)
        {
            var map = _mapper.Map<Players>(command);

            if (!map.Validate.IsValid)
                throw new ValidationException(map.Validate.Errors);

            var addPlayerResult = await _domain.CreateAsync(map);
            var mapResult = _mapper.Map<PlayerDTO>(addPlayerResult);

            return mapResult;
        }
    }
}
