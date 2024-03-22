using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
