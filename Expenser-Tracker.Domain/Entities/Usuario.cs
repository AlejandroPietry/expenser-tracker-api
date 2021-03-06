using System;
using System.Collections.Generic;

namespace Expenser_Tracker.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<Transacao> Transacaoes { get; set; }
    }
}
