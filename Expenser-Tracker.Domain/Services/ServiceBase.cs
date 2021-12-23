using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using System.Collections.Generic;

namespace Expenser_Tracker.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.Get();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
