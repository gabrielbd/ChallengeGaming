using Microsoft.EntityFrameworkCore.Storage;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Infra.Contexts;


namespace PredifyGaming.Infra.Repositories
{
    public class UnitOfWork<TEntity> : IUnitOfWork <TEntity>
        where TEntity : class
    {
        private readonly SqlContexts _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(SqlContexts context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
             await _transaction!.CommitAsync();
        }
        public async Task RollBackAsync()
        {
            await _transaction!.RollbackAsync();
        }

        public IBaseRepository<TEntity> BaseRepository => new BaseRepository<TEntity>(_context);
        public IPlayersRepository PlayersRepository => new PlayersRepository(_context);
        public IGamesRepository GamesRepository => new GamesRepository(_context);
        public IPlaysResultRepository PlaysResultRepository => new PlaysResultRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
  
    }
}