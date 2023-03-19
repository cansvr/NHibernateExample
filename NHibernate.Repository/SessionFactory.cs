using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Data.Base;
using NHibernateExample.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Repository
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;
        private static readonly object Padlock = new object();

        private SessionFactory()
        {

        }
        public static ISessionFactory GetFactory()
        {
            lock (Padlock)
            {
                if (_sessionFactory == null)
                {
                    try
                    {
                        string connStr = DbSettings.GetConnectionString("ConnectionString");

                        _sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(connStr))
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Users>())
                           .ExposeConfiguration(x => x.SetProperty("connection.release_mode", "on_close")/*.SetInterceptor(new SqlStatementInterceptor())*/)
                           .BuildSessionFactory();
                    }

                    catch (Exception exc)
                    {
                        throw new Exception(string.Format("Bağlantı sağlanamadı.Detay:{0}", exc.Message + " \n" + exc.InnerException));
                    }
                }
            }

            return _sessionFactory;
        }

        public static ISessionFactory GetFactory(String connectionString)
        {
            lock (Padlock)
            {
                if (_sessionFactory == null)
                {
                    try
                    {
                        _sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Users>())
                           .ExposeConfiguration(x => x.SetProperty("connection.release_mode", "on_close"))
                           .BuildSessionFactory();
                    }
                    catch (Exception exc)
                    {
                        throw new Exception(string.Format("Bağlantı sağlanamadı.Detay:{0}", exc.Message));
                    }
                }
            }

            return _sessionFactory;
        }
    }
}
