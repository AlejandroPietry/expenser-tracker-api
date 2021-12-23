using Expenser_Tracker.Domain.Interfaces.Repositorios;
using Expenser_Tracker.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expenser_Tracker.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where,int skip = 0, int take = 25)
        {
            return _context.Set<T>()
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public IEnumerable<T> GetAllAsNoTracking(Expression<Func<T, bool>> where,int skip = 0, int take = 25)
        {
            return _context.Set<T>()
                .Where(where)
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
