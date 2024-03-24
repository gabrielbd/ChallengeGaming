using PredifyGaming.Infra.Logs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Infra.Logs.Interfaces
{
    public interface ILogPlaysResultPersistence
    {
        Task CreateAsync(LogPlaysResultModel entity);
        List<LogPlaysResultModel> GetAllByIdGame(long GameId);
    }
}
