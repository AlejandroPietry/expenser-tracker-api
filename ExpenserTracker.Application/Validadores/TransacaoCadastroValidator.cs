using Expenser_Tracker.Domain.Enums;
using ExpenserTracker.Application.DTO;
using FluentValidation;
using System;

namespace ExpenserTracker.Application.Validadores
{
    public class TransacaoCadastroValidator : AbstractValidator<TransacaoCadastro_DTO>
    {
        public TransacaoCadastroValidator()
        {
            RuleFor(e => e.Titulo)
                .Length(1, 100)
                .WithMessage("O titulo precisa ter entre 1 e 100 caracteres!")
                .NotNull()
                .NotEmpty()
                .WithMessage("O titulo não pode ser nulo e nem vazio.");

            RuleFor(e => e.Valor)
                .LessThan(999999)
                .WithMessage("O valor precisa ser menor que 999999");

            RuleFor(e => e.TipoTransacao)
                .Must(VerificarTipoTransacao)
                .WithMessage("Tipo de transacao invalida.");
        }

        private static bool VerificarTipoTransacao(TipoTransacao tipoTransacao) =>
            (int)tipoTransacao < 2;
            
    }
}
