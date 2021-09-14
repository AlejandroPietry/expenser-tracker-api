using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using ExpenserTracker.Application.Interfaces;

namespace ExpenserTracker.Application
{
    public class TransacaoAppService : AppServiceBase<Transacao>, ITransacaoAppService
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoAppService(ITransacaoService transacaoService) : base(transacaoService)
        {
            _transacaoService = transacaoService;
        }
    }
}
