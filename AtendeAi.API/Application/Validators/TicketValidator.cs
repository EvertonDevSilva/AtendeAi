using AtendeAi.API.Application.DTOs;
using FluentValidation;

namespace AtendeAi.API.Application.Validators
{
    public class TicketValidator : AbstractValidator<TicketDTO>
    {
        public TicketValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().NotNull().WithMessage("O título é obrigatório.")
                .Length(5, 50).WithMessage("O título deve ter entre 5 e 50 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().NotNull().WithMessage("A descrição é obrigatória.")
                .Length(5, 300).WithMessage("A descrição deve ter entre 5 e 300 caracteres.");
        }
    }
}
