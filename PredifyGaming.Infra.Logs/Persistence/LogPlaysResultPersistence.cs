using MongoDB.Driver;
using PredifyGaming.Infra.Logs.Contexts;
using PredifyGaming.Infra.Logs.Interfaces;
using PredifyGaming.Infra.Logs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Infra.Logs.Persistence
{
    public class LogPlaysResultPersistence : ILogPlaysResultPersistence
    {
        private readonly MongoDBContext _mongoContext;

        public LogPlaysResultPersistence(MongoDBContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task CreateAsync(LogPlaysResultModel entity)
        {
           await _mongoContext.LogPlaysResult.InsertOneAsync(entity);
        }

        public async Task<List<LogPlaysResultModel>> GetAllByIdGameAsync(long GameId)
        {
            var filter = Builders<LogPlaysResultModel>.Filter
                .Eq(log => log.GameId,GameId);

            return await _mongoContext
                .LogPlaysResult
                .Find(filter)
                .ToListAsync();
        }
    }
}
