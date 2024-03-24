using PredifyGaming.Infra.Logs.Models;


namespace PredifyGaming.Infra.Logs.Interfaces
{
    public interface ILogPlaysResultPersistence
    {
        Task CreateAsync(LogPlaysResultModel entity);
        List<LogPlaysResultModel> GetAllByIdGame(long GameId);
    }
}
