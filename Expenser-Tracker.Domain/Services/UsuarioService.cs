using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Domain.Interfaces.Servicos;

namespace Expenser_Tracker.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio) : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
    }
}
