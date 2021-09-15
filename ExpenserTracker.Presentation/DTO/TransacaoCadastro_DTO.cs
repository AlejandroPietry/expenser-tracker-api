using Expenser_Tracker.Domain.Enums;
using System;

namespace ExpenserTracker.Presentation.DTO
{
    public class TransacaoCadastro_DTO
    {
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
