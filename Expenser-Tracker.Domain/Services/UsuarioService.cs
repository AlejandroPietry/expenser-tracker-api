using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Expenser_Tracker.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio) : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario GetUsuarioByExpression(Expression<Func<Usuario, bool>> expression)
        {
            return _usuarioRepositorio.GetUsuarioByExpression(expression);
        }
        public IAsyncEnumerable<Usuario> GetUsuarios()
        {
            return _usuarioRepositorio.GetUsuarios();
        }
    }
}
