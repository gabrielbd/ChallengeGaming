using AutoMapper;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var userData = _mapper.Map<PlaysResult>(entity);
            return await _domain.CreateAsync(userData);
        }
        
        public async Task<string> GameResultFormat(PlaysResult playsResult)
        {
            var valueTotalPoints = await _domain.GetByPlayerIsGameAsync(playsResult.PlayerId, playsResult.GameId);
            var totalPoints = valueTotalPoints.Sum(x => x.PointsResult);

            return await Task.Run(() =>
            {
                var gameResult = 
                        ($"Jogada realizada com sucesso, resultado: {playsResult.PointsResult} pontos.{Environment.NewLine}" +
                        $"- Pontos Acumulados        : {totalPoints}{Environment.NewLine}" +
                        $"- Name do Player  : {playsResult.Players.Name}{Environment.NewLine}" +
                        $"- Nome do Game    : {playsResult.Games.Name}{Environment.NewLine}" +
                        $"- ID   do Player  : {playsResult.PlayerId} - {playsResult.Players.Name}{Environment.NewLine}" +
                        $"- ID   do Game    : {playsResult.GameId}   - {playsResult.Games.Name}{Environment.NewLine}" +
                        $"- Sua jogada foi realizada : {playsResult.TimeStamp}");
                return gameResult;
            });
        }

        public async Task<List<PlaysResultDTO>> GetByPlayerIsGameAsync(long idPlayer, long idGame)
        {
            var result = await _domain.GetByPlayerIsGameAsync(idPlayer,idGame);
            return _mapper.Map<List<PlaysResultDTO>>(result);
        }
    }
}
