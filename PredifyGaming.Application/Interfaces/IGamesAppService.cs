using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Application.Interfaces
{
    public interface IGamesAppService : IBaseAppService<Games>
    {
        Task<GameDTO> CreateGameAsync(CreateGameCommand command);

    }
}
