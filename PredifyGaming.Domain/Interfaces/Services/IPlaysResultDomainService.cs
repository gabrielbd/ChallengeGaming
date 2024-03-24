using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Domain.Interfaces.Services
{
    public interface IPlaysResultDomainService : IBaseDomainService<PlaysResult>
    {
        Task<List<PlaysResult>> GetAllByGameAsync(long idGame);
        Task<List<PlaysResult>> GetAllByPlayerAsync(long idPlayer);
        Task<List<PlaysResult>> GetByPlayerIsGameAsync(long idPlayer, long idGame);

    }
}
