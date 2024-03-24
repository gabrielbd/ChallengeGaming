using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Domain.Interfaces.Repositories
{
    public interface IPlaysResultRepository : IBaseRepository<PlaysResult>
    {
        Task<List<PlaysResult>> GetAllByGameAsync(long idGame);
        Task<List<PlaysResult>> GetAllByPlayerAsync(long idPlayer);
        Task<List<PlaysResult>> GetByPlayerIsGameAsync(long idPlayer , long idGame);


    }
}
