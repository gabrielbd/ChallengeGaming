using FluentValidation;
using PredifyGaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
