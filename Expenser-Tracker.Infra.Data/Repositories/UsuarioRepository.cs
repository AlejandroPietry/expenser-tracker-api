using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public async IAsyncEnumerable<Usuario> GetUsuarios()
        {
            foreach(var usuario in _context.Usuarios)
            {
                await Task.Delay(1000);
                yield return usuario;
            }
        }
    }
}
