using ExpenserTracker.Application.DTO;
using FluentValidation;

namespace ExpenserTracker.Application.Validadores
{
    public class LoginValidator : AbstractValidator<Login_DTO>
    {
        public LoginValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email não pode ser nulo ou vazio.")
                .EmailAddress()
                .WithMessage("Precisa está no formato de email.")
                .Length(5, 201)
                .WithMessage("Email tem que ter menos de 200 caracteres.");

            RuleFor(e => e.Senha)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha não pode ser nulo ou vazio.")
                .Length(7, 201)
                .WithMessage("Tem que ter entre 7 e 200 caracteres");

        }
    }
}
