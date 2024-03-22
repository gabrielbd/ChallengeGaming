using FluentValidation;
using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Domain.Validations
{
    public class PlayersValidation : AbstractValidator<Players>
    {
        public PlayersValidation() {

            RuleFor(u => u.Name)
            .NotEmpty()
            .Length(3, 150)
            .WithMessage("Nome do jogador é inválido");

        }
    }
}
