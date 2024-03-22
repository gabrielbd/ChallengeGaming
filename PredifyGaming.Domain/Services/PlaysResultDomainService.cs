using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Domain.Services
{
    public class PlaysResultDomainService : BaseDomainService<PlaysResult> , IPlaysResultDomainService
    {
        private readonly IPlaysResultRepository _repositoryPlays;
        private readonly IPlayersDomainService _repositoryPlayers;
        private readonly IGamesDomainService _repositoryGames;

        public PlaysResultDomainService(IPlaysResultRepository repositoryPlays, IPlayersDomainService repositoryPlayers, IGamesDomainService repositoryGames)
        :base(repositoryPlays)
        {
            this._repositoryPlays = repositoryPlays;
            _repositoryPlayers = repositoryPlayers;
            _repositoryGames = repositoryGames;
        }

        public async Task<List<PlaysResult>> GetAllByGameAsync(long idGame)
        {
            return await _repositoryPlays.GetAllByGameAsync(idGame);
        }

        public async Task<List<PlaysResult>> GetAllByPlayerAsync(long idPlayer)
        {
            return await _repositoryPlays.GetAllByPlayerAsync(idPlayer);
        }

        public override async Task<PlaysResult> CreateAsync(PlaysResult entity)
        {
            var playerById = await _repositoryPlayers.GetByIdAsync(entity.PlayerId);
            var gameById = await _repositoryGames.GetByIdAsync(entity.GameId);
            long pointsGenerator = (long)new Random().Next(-15, 21);

            if (playerById is null)
                throw new Exception($@"ID Player {entity.PlayerId} não encontrado.");

            if (gameById is null)
                throw new Exception($@"ID {entity.GameId} não pertence a um Game");

                entity.PointsResult = pointsGenerator;
                var data = await _repositoryPlays.CreateAsync(entity);
                return data;
        }
    }
}
