using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Application.Interfaces
{
    public interface IGamesAppService : IBaseAppService<Games , GamesDTO>
    {
    }
}
