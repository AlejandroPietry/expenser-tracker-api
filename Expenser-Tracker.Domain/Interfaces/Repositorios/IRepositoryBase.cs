using System.Collections.Generic;

namespace Expenser_Tracker.Domain.Interfaces.Repositorios
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        void Add(T entity);
        IEnumerable<T> Get();
        IEnumerable<T> GetAllAsNoTracking();
        void Update(T entity);
        void Remove(T entity);
    }
}
