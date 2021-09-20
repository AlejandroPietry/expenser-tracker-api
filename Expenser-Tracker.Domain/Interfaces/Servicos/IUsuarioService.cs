using Expenser_Tracker.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Expenser_Tracker.Domain.Interfaces.Servicos
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario GetUsuarioByExpression(Expression<Func<Usuario, bool>> expression);
    }
}
