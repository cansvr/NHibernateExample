using System;
using System.Collections.Generic;

namespace NHibernate.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable
    {
        public T Get(object id)
        {
            try
            {
                using (var session = SessionFactory.GetFactory().OpenSession())
                {
                    return session.Get<T>(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("{1}.Get.Err : {0}", e.Message, typeof(T).FullName), e);
            }
        }

        public IList<T> GetAll()
        {
            try
            {
                using (var session = SessionFactory.GetFactory().OpenSession())
                {
                    var cr = session.CreateCriteria(typeof(T));
                    return cr.List<T>();
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("GetAll.Err : {0}", e.Message), e);
            }
        }

        public T InsertOrUpdate(T obj)
        {
            try
            {
                using (var session = SessionFactory.GetFactory().OpenSession())
                {
                    session.SaveOrUpdate(obj);
                    session.Flush();
                    return obj;
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public T Update(T obj)
        {
            try
            {
                using (var sess = SessionFactory.GetFactory().OpenSession())
                {
                    sess.Update(obj);
                    sess.Flush();
                    return obj;
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(T obj)
        {
            try
            {
                using (var session = SessionFactory.GetFactory().OpenSession())
                {
                    session.Delete(obj);
                    session.Flush();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void Dispose()
        {

        }
    }
}
