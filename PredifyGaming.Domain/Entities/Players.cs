using FluentValidation;
using FluentValidation.Results;
using PredifyGaming.Domain.Validations;


namespace PredifyGaming.Domain.Entities
{
    public class Players : IEntity<long>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public List<PlaysResult>? PlaysResults { get; set; }
        public ValidationResult Validate
        => new PlayersValidation().Validate(this);
        
    }
}
