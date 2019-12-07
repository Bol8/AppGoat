using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AppGoat.Domain.RepositoryServices;

namespace AppGoat.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }


        public T GetElement(object id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetElements()
        {
            return _table.ToList();
        }

        public IEnumerable<T> GetElements(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate);
        }

        public void Add(T element)
        {
            _table.Add(element);
        }

        public void Edit(T element)
        {
            _context.Entry(element).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var element = GetElement(id);
            _table.Remove(element);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}