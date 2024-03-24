using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PredifyGaming.Infra.Logs.Models
{
    public class LogPlaysResultModel
    {

        [BsonId]
        public ObjectId Id { get; set; }
        public long PlayerId { get; set; }
        public long GameId { get; set; }
        public string? DescriptionPlayer { get; set; }
        public string? DescriptionGame { get; set; }

        public long BalancePlayer { get; set; }
        public DateTime TimeStamp { get; set; } 
    }
}
