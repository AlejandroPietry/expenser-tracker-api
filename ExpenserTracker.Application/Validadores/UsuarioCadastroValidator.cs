using ExpenserTracker.Application.DTO;
using FluentValidation;

namespace ExpenserTracker.Application.Validadores
{
    public class UsuarioCadastroValidator : AbstractValidator<UsuarioCadastro_DTO>
    {
        public UsuarioCadastroValidator()
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
                .NotEmpty()
                .NotNull()
                .WithMessage("Senha não pode ser nulo ou vazio.")
                .Length(7, 20)
                .WithMessage("A senha precisa ter entre 7 e 20 caracteres.");

            RuleFor(e => e.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome não pode ser nulo ou vazio.")
                .Length(3, 40)
                .WithMessage("Nome tem que ter entre 3 e 40 caracteres.");
        }
    }
}
