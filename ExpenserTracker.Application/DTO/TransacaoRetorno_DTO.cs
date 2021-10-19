using Expenser_Tracker.Domain.Enums;

namespace ExpenserTracker.Application.DTO
{
    public class TransacaoRetorno_DTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
    }
}
