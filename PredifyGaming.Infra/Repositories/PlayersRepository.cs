using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Infra.Contexts;


namespace PredifyGaming.Infra.Repositories
{
    public class PlayersRepository : BaseRepository<Players> , IPlayersRepository
    {
        private readonly SqlContexts _contexts;
        public PlayersRepository(SqlContexts context) : base(context)
        {
            _contexts = context;
        }
    }
}
