using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace Expenser_Tracker.Domain.Services
{
    public class TransacaoService : ServiceBase<Transacao>, ITransacaoService
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public TransacaoService(ITransacaoRepositorio transacaoRepositorio) : base(transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }

        public void DeletarTodosDoUsuario(Guid userId)
        {
            _transacaoRepositorio.DeletarTodosDoUsuario(userId);
        }

        public IEnumerable<Transacao> GetAllByUserId(Guid userId)
        {
            return _transacaoRepositorio.GetAllByUserId(userId);
        }
    }
}
