using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Domain.Interfaces.Servicos;

namespace Expenser_Tracker.Domain.Services
{
    public class TransacaoService : ServiceBase<Transacao>, ITransacaoService
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public TransacaoService(ITransacaoRepositorio transacaoRepositorio) : base(transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }
    }
}
