using FluentValidation;
using PredifyGaming.Domain.Entities;

namespace PredifyGaming.Domain.Validations
{
    public class PlaysResultValidation : AbstractValidator<PlaysResult>
    {
        public PlaysResultValidation()
        {

            RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("Id é obrigatório");

        }
    }
}
