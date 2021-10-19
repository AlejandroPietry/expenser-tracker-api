using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenser_Tracker.Infra.Data.Repositories
{
    public class TransacaoRepository : RepositoryBase<Transacao>, ITransacaoRepositorio
    {
        public TransacaoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public void DeletarTodosDoUsuario(Guid userId)
        {
            Parallel.ForEach(GetAllByUserId(userId), item =>
            {
                Remove(item);
            });
        }

        public IEnumerable<Transacao> GetAllByUserId(Guid userId)
        {
            return _context.Transacoes.Where(x => x.IdUsuario == userId);
        }
    }
}
