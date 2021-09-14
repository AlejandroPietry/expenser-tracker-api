using Expenser_Tracker.Domain.Enums;
using System;

namespace Expenser_Tracker.Domain.Entities
{
    public class Transacao
    {
        public int Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Usuario Usuario { get; set; } 
    }
}
