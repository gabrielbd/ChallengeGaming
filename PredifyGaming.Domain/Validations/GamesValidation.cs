using FluentValidation;
using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Domain.Validations
{
    public class GamesValidation : AbstractValidator<Games>
    {
        public GamesValidation()
        {
            RuleFor(u => u.Id)
               .NotEmpty()
               .WithMessage("Id é obrigatório");

            RuleFor(u => u.Name)
            .NotEmpty()
            .Length(2, 150)
            .WithMessage("Nome do jogo inválido");
        }
    }
}
