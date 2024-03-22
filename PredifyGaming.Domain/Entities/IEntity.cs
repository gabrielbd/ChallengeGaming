using FluentValidation.Results;

namespace PredifyGaming.Domain.Entities
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
        public ValidationResult Validate { get; }
    }
}
