using NHibernate.Data.Base;
using NHibernate.Repository;
using System.Web.Http;

namespace NHibernate.Service.Base
{

    public class BaseController : ApiController
    {
        public string ConnectionString { get; set; }
        public ISessionFactory Session { get; set; }
        public string BaseURL { get; set; }

        public BaseController()
        {
            ConnectionString = DbSettings.GetConnectionString("ConnectionString");

            Session = SessionFactory.GetFactory(ConnectionString);
        }
    }
}
