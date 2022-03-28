using Expenser_Tracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Expenser_Tracker.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositoryBase<Usuario>
    {
        Usuario GetUsuarioByExpression(Expression<Func<Usuario, bool>> expression);
        IAsyncEnumerable<Usuario> GetUsuarios();
    }
}
