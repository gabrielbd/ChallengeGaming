﻿using MongoDB.Driver;
using PredifyGaming.Infra.Logs.Contexts;
using PredifyGaming.Infra.Logs.Interfaces;
using PredifyGaming.Infra.Logs.Models;

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

        public List<LogPlaysResultModel> GetAllByIdGame(long GameId)
        {
            var filter = Builders<LogPlaysResultModel>.Filter
                .Eq(log => log.GameId,GameId);

            return _mongoContext
                .LogPlaysResult
                .Find(filter)
                .ToList();
        }
    }
}
