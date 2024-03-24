using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Infra.Contexts;

namespace PredifyGaming.Infra.Repositories
{
    public class GamesRepository : BaseRepository<Games>, IGamesRepository
    {
        private readonly SqlContexts _contexts;
        public GamesRepository(SqlContexts context) : base(context)
        {
            _contexts = context;
        }
    }
}
