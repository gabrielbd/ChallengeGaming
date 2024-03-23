using PredifyGaming.Infra.Logs.Models;
using PredifyGaming.Infra.Logs.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace PredifyGaming.Infra.Logs.Contexts
{
    public class MongoDBContext
    {
        private readonly MongoDBSettings? _mongoDBSettings;
        private IMongoDatabase _mongoDatabase;

        public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings.Value;

            var client = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings.Host));

            if (_mongoDBSettings.IsSSL)
                client.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                };

            _mongoDatabase = new MongoClient(client).GetDatabase(_mongoDBSettings.Name);

        }

        public IMongoCollection<LogPlaysResultModel> LogPlaysResult
            => _mongoDatabase.GetCollection<LogPlaysResultModel>("LogPlaysResult");
    }
}
