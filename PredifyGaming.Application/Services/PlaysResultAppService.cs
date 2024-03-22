using AutoMapper;
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
    public class PlaysResultAppService : BaseAppService<PlaysResult , PlaysResultDTO>, IPlaysResultAppService
    {

        private readonly IPlaysResultDomainService _domain;
        private readonly IMapper _mapper;


        public PlaysResultAppService(IBaseDomainService<PlaysResult> domainService, IPlaysResultDomainService domain, IMapper mapper)
            : base(domainService, mapper)
        {
            this._mapper = mapper;
            this._domain = domain;
        }

        public async Task<List<PlaysResultDTO>> GetAllByGameAsync(long idGame)
        {
            var result = await _domain.GetAllByGameAsync(idGame);
            return _mapper.Map<List<PlaysResultDTO>>(result);
        }

        public async Task<List<PlaysResultDTO>> GetAllByPlayerAsync(long idPlayer)
        {
            var result = await _domain.GetAllByPlayerAsync(idPlayer);
            return _mapper.Map<List<PlaysResultDTO>>(result);
        }
        public override async Task<PlaysResult> CreateAsync(PlaysResultDTO entity)
        {
            var data = await _domain.CreateAsync(_mapper.Map<PlaysResult>(entity));
            return data;
        }

        public async Task<string> GameResultFormat(PlaysResult playsResult)
        {
            return await Task.Run(() =>
            {
                var gameResult = 
                        ($"Jogada realizada com sucesso, resultado: {playsResult.PointsResult} pontos.{Environment.NewLine}" +
                        $"- ID Player : {playsResult.PlayerId}{Environment.NewLine}" +
                        $"- ID Game : {playsResult.GameId}{Environment.NewLine}" +
                        $"- Sua jogada foi realizada : {playsResult.TimeStamp}");
                return gameResult;
            });
        }
    }
}
