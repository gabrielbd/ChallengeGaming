using Microsoft.EntityFrameworkCore;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Infra.Contexts;

namespace PredifyGaming.Infra.Repositories
{
    public class PlaysResultRepository : BaseRepository<PlaysResult> , IPlaysResultRepository
    {
        private readonly SqlContexts _contexts;

        public PlaysResultRepository(SqlContexts context) : base(context)
        {
            _contexts = context;
        }


        public Task<List<PlaysResult>> GetAllByGameAsync(long idGame)
        {
            return _contexts.PlaysResult.Where(x => x.GameId == idGame).ToListAsync();
        }

        public Task<List<PlaysResult>> GetAllByPlayerAsync(long idPlayer)
        {
            return _contexts.PlaysResult.Where(x => x.PlayerId == idPlayer).ToListAsync();
        }

        public Task<List<PlaysResult>> GetByPlayerIsGameAsync(long idPlayer, long idGame)
        {
            return _contexts.PlaysResult
                .Where(x => x.PlayerId == idPlayer && x.GameId == idGame)
                .ToListAsync();
        }
    }
}
