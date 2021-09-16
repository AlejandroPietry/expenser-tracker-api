using Expenser_Tracker.Domain.Enums;

namespace ExpenserTracker.Application.DTO
{
    public class TransacaoCadastro_DTO
    {
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
    }
}
