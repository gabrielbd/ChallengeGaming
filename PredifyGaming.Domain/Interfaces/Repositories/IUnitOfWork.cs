

namespace PredifyGaming.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork<TEntity> : IDisposable
        where TEntity : class
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
        IBaseRepository<TEntity> BaseRepository { get; }
        IPlayersRepository PlayersRepository { get; }
        IGamesRepository GamesRepository { get; }
        IPlaysResultRepository PlaysResultRepository { get; }

    }
}
