using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Expenser_Tracker.Domain.Interfaces.Repositorios
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        void Add(T entity);
        IEnumerable<T> Get(Expression<Func<T, bool>> where, int skip = 0, int take = 25);
        IEnumerable<T> GetAllAsNoTracking(Expression<Func<T, bool>> where, int skip = 0, int take = 25);
        void Update(T entity);
        void Remove(T entity);
    }
}
