using NHibernate.Data.Entities;
using NHibernate.Repository;
using NHibernateExample.Data;
using System;
using System.Collections.Generic;

namespace NHibernate.Service
{
    public class UserService:IDisposable
    {
        public void Dispose()
        {

        }

        public CustomResult<IList<User>> Get(string userName)
        {
            CustomResult<IList<User>> result = new CustomResult<IList<User>>();
            UserRepository repoWorkOrder = new UserRepository();

            if (string.IsNullOrEmpty(userName))
            {
                repoWorkOrder.GetAll();
            }
            else
            {
                //repoWorkOrder.Get();
            }

            return result;
        }
    }
}
