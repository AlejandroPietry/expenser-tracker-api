using Expenser_Tracker.Domain.Interfaces.Servicos;
using ExpenserTracker.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace ExpenserTracker.Application
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;
        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(T entity)
        {
            _serviceBase.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public T GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(T entity)
        {
            _serviceBase.Remove(entity);
        }

        public void Update(T entity)
        {
            _serviceBase.Update(entity);
        }
    }
}
