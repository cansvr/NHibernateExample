using NHibernate.Data.Entities;
using NHibernate.Service;
using NHibernate.Service.Base;
using NHibernateExample.Data;
using System.Collections.Generic;
using System.Web.Http;

namespace NHibernate.Api.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        [Route("Users/Get")]
        public CustomResult<IList<User>> Get(string userId)
        {
            CustomResult<IList<User>> result = new CustomResult<IList<User>>();

            using (UserService service = new UserService())
            {
                result = service.Get(userId);
            }

            return result;
        }
    }
}
