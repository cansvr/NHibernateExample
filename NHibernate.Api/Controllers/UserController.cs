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
        [Route("User/Get")]
        public CustomResult<IList<Users>> Get(CustomRequest filter)
        {
            CustomResult<IList<Users>> result = new CustomResult<IList<Users>>();

            using (UserService service = new UserService())
            {
                result = service.Get(filter);
            }

            return result;
        }

        [HttpPost]
        [Route("User/InsertOrUpdate")]
        public CustomResult<Users> InsertOrUpdate(Users user)
        {
            CustomResult<Users> result = new CustomResult<Users>();

            using (UserService service = new UserService())
            {
                result = service.InsertOrUpdate(user);
            }

            return result;
        }

        [HttpPost]
        [Route("User/Update")]
        public CustomResult<Users> Update(Users user)
        {
            CustomResult<Users> result = new CustomResult<Users>();

            using (UserService service = new UserService())
            {
                result = service.Update(user);
            }

            return result;
        }


        [HttpPost]
        [Route("User/Delete")]
        public CustomResult<Users> Delete(Users user)
        {
            CustomResult<Users> result = new CustomResult<Users>();

            using (UserService service = new UserService())
            {
                result = service.Delete(user);
            }

            return result;
        }
    }
}
