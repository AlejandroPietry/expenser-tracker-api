using Expenser_Tracker.Domain.Entities;
using ExpenserTracker.Application.DTO;
using System.Collections.Generic;

namespace ExpenserTracker.Application.Interfaces
{
    public interface ITransacaoAppService : IAppServiceBase<Transacao>
    {
        public void Criar(TransacaoCadastro_DTO model, string guildUserId);
        public IEnumerable<TransacaoRetorno_DTO> GetAllByUserId(string userId);
        public void DeletarTodosDoUsuario(string idUsuario);

    }
}
