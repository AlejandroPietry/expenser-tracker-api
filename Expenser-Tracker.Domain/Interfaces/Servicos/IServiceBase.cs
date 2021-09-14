using System.Collections.Generic;

namespace Expenser_Tracker.Domain.Interfaces.Servicos
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Remove(T entity);
    }
}
