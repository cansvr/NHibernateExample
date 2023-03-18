using System.Collections.Generic;

namespace NHibernate.Repository
{
    public interface IRepository<T>
    {
        T Get(object id);
        IList<T> GetAll();
        T InsertOrUpdate(T obj);
        T Update(T obj);
        void Delete(T obj);
    }
}
