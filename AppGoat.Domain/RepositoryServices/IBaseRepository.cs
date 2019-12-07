using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AppGoat.Domain.RepositoryServices
{
    public interface IBaseRepository<T>
    {
        T GetElement(object id);

        IEnumerable<T> GetElements();

        IEnumerable<T> GetElements(Expression<Func<T, bool>> predicate);

        void Add(T element);

        void Edit(T element);

        void Delete(object id);

        void SaveChanges();
    }
}