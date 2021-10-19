using Expenser_Tracker.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Expenser_Tracker.Domain.Interfaces.Repositorios
{
    public interface ITransacaoRepositorio : IRepositoryBase<Transacao>
    {
        public IEnumerable<Transacao> GetAllByUserId(Guid userId);
        public void DeletarTodosDoUsuario(Guid userId);
    }
}
