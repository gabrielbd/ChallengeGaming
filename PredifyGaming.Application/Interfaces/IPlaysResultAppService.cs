using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Infra.Logs.Models;

namespace PredifyGaming.Application.Interfaces
{
    public interface IPlaysResultAppService : IBaseAppService<PlaysResult>
    {

        Task<PlaysResultDTO> CreatePlayAsync(CreatePlayResultCommand command);

        Task<List<PlaysResultDTO>> GetAllByGameAsync(long idGame);
        Task<List<PlaysResultDTO>> GetAllByPlayerAsync(long idPlayer);
        Task<string> GameResultFormat(PlaysResultDTO gameResult);
        string LeaderBoardFormat(long gameId);
        Task<List<PlaysResultDTO>> GetByPlayerIsGameAsync(long idPlayer, long idGame);
        List<LogPlaysResultModel> GetLogPlaysResultByIdGame(long idGame);

    }
}
