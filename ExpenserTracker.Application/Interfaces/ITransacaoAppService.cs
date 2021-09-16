using Expenser_Tracker.Domain.Entities;
using ExpenserTracker.Application.DTO;

namespace ExpenserTracker.Application.Interfaces
{
    public interface ITransacaoAppService : IAppServiceBase<Transacao>
    {
        public void Criar(TransacaoCadastro_DTO model);
    }
}
