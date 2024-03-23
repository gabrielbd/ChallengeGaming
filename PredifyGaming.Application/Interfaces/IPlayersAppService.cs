using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Application.Interfaces
{
    public interface IPlayersAppService : IBaseAppService<Players>
    {
        Task<PlayerDTO> CreatePlayerAsync(CreatePlayerCommand command);

    }
}
