using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Infra.Data.Context;

namespace Expenser_Tracker.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
