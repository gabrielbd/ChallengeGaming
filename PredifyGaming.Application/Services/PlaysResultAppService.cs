using AutoMapper;
using MediatR;
using MongoDB.Driver.Linq;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;
using PredifyGaming.Infra.Logs.Interfaces;
using PredifyGaming.Infra.Logs.Models;
using System.Text;


namespace PredifyGaming.Application.Services
{
    public class PlaysResultAppService : BaseAppService<PlaysResult>, IPlaysResultAppService
    {

        private readonly IPlaysResultDomainService _domain;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        ILogPlaysResultPersistence _logPlaysResultPersistence;


        public PlaysResultAppService(IBaseDomainService<PlaysResult> domainService, IPlaysResultDomainService domain, IMapper mapper, IMediator mediator, ILogPlaysResultPersistence logPlaysResultPersistence)
            : base(domainService, mapper)
        {
            this._mapper = mapper;
            this._domain = domain;
            this._mediator = mediator;
            _logPlaysResultPersistence = logPlaysResultPersistence;
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

        public async Task<PlaysResultDTO> CreatePlayAsync(CreatePlayResultCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        public List<LogPlaysResultModel> GetLogPlaysResultByIdGame(long idGame)
        {
            return _logPlaysResultPersistence.GetAllByIdGame(idGame);
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

        public string LeaderBoardFormat(long gameId)
        {
            var playsResults = _logPlaysResultPersistence.GetAllByIdGame(gameId);
            var playerScores = playsResults
                .GroupBy(x => x.PlayerId)
                .Select(group => new
                {
                    PlayerId = group.Key,
                    TotalScore = group.Sum(x => x.BalancePlayer)
                })
                .OrderByDescending(x => x.TotalScore)
                .Take(100)
                .ToList();

            var leaderboard = new StringBuilder();
            leaderboard.AppendLine($" Ranking Total de Pontos - GameID : {gameId}:");
            leaderboard.AppendLine("------------------------------------------------");
            int rank = 1;
            foreach (var playerScore in playerScores)
            {
               var player = playsResults.FirstOrDefault(x => x.PlayerId == playerScore.PlayerId);
               leaderboard.AppendLine($"{rank++}: PlayerId: {player.PlayerId}, Name: {player.DescriptionPlayer}, TotalScore: {playerScore.TotalScore}");
            }
            leaderboard.AppendLine($"Data da última atualização do ranking: {playsResults.Max(x => x.TimeStamp)}");
            return leaderboard.ToString();
        }
    }
}
