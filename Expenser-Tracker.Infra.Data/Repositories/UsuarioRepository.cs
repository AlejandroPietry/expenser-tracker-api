using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Infra.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Expenser_Tracker.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Usuario GetUsuarioByExpression(Expression<Func<Usuario, bool>> expression)
        {
            return _context.Usuarios.Where(expression).FirstOrDefault();
        }
    }
}
