using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;

namespace PredifyGaming.Application.Interfaces
{
    public interface IPlaysResultAppService : IBaseAppService<PlaysResult>
    {

        Task<PlaysResultDTO> CreatePlayAsync(CreatePlayResultCommand command);

        Task<List<PlaysResultDTO>> GetAllByGameAsync(long idGame);
        Task<List<PlaysResultDTO>> GetAllByPlayerAsync(long idPlayer);
        Task<string> GameResultFormat(PlaysResultDTO gameResult);
        Task<List<PlaysResultDTO>> GetByPlayerIsGameAsync(long idPlayer, long idGame);

    }
}
