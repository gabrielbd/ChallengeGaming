using AutoMapper;
using MediatR;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;
using PredifyGaming.Infra.Logs.Interfaces;
using PredifyGaming.Infra.Logs.Models;


namespace PredifyGaming.Application.Services
{
    public class PlaysResultAppService : BaseAppService<PlaysResult>, IPlaysResultAppService
    {

        private readonly IPlaysResultDomainService _domain;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public PlaysResultAppService(IBaseDomainService<PlaysResult> domainService, IPlaysResultDomainService domain, IMapper mapper, IMediator mediator)
            : base(domainService, mapper)
        {
            this._mapper = mapper;
            this._domain = domain;
            this._mediator = mediator;
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
  

        public async Task<List<PlaysResultDTO>> GetByPlayerIsGameAsync(long idPlayer, long idGame)
        {
            var result = await _domain.GetByPlayerIsGameAsync(idPlayer,idGame);
            return _mapper.Map<List<PlaysResultDTO>>(result);
        }

        public async Task<string> GameResultFormat(PlaysResultDTO playsResult)
        {
            var valueTotalPoints = await _domain.GetByPlayerIsGameAsync(playsResult.PlayerId, playsResult.GameId);
            var totalPoints = valueTotalPoints.Sum(x => x.PointsResult);

            return await Task.Run(() =>
            {
                var gameResult =
                        ($"Jogada realizada com sucesso, resultado: {playsResult.PointsResult} pontos.{Environment.NewLine}" +
                        $"- Pontos  Total   : {totalPoints}             {Environment.NewLine}" +
                        $"- Name do Player  : {playsResult.PlayerName}  {Environment.NewLine}" +
                        $"- Nome do Game    : {playsResult.GameName}    {Environment.NewLine}" +
                        $"- ID   do Player  : {playsResult.PlayerId}    {Environment.NewLine}" +
                        $"- ID   do Game    : {playsResult.GameId}      {Environment.NewLine}" +
                        $"- Data da Jogada  : {playsResult.TimeStamp}");
                return gameResult;
            });
        }

        public async Task<PlaysResultDTO> CreatePlayAsync(CreatePlayResultCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
