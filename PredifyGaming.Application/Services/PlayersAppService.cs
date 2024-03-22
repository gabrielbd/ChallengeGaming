using AutoMapper;
using FluentValidation;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Commands.PlaysResult;
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
        private readonly IPlayersDomainService _domain;
        private readonly IMapper _mapper;
        public PlayersAppService(IBaseDomainService<Players> domainService , IPlayersDomainService domain , IMapper mapper)
            : base(domainService, mapper)
        {
            this._mapper = mapper;
            this._domain = domain;
        }

        public override async Task<Players> CreateAsync(PlayersDTO entity)
        {
            var userData = _mapper.Map<Players>(entity);
            var validation = userData.Validate;

            if (!validation.IsValid)
                throw new ValidationException(string.Join(Environment.NewLine, validation.Errors.Select(error => error.ErrorMessage)));

            return await _domain.CreateAsync(userData);
        }
    }
}
