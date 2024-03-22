using FluentValidation.Results;
using PredifyGaming.Domain.Validations;

namespace PredifyGaming.Domain.Entities
{
    public class PlaysResult : IEntity<long>
    {
        public long Id { get; set; }
        public long PlayerId { get; set; } 
        public long GameId { get; set; } 
        public long PointsResult { get; set; }
        public DateTime TimeStamp { get; set; }
        public Players? Players { get; set; } 
        public Games? Games { get; set; }
        public ValidationResult Validate
        => new PlaysResultValidation().Validate(this);
    }
}
