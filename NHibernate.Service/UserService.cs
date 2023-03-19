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

        public CustomResult<IList<Users>> Get(CustomRequest filter)
        {
            CustomResult<IList<Users>> result = new CustomResult<IList<Users>>() { IsSucceeded=false};
            UserRepository userRepository = new UserRepository();
            IList<Users> userList = new List<Users>();
            Users user = new Users();

            if (filter == null)
            {
                result.IsSucceeded = false;
                result.ErrorMessage = "Parametreler boş gönderilemez.";
                return result;
            }

            if (filter.UserId == null)
            {
                userList = userRepository.GetAll();
                result.TransactionResult = userList;
            }
            else
            {
                user = userRepository.Get(filter.UserId);
                userList.Add(user);
                result.TransactionResult = userList;
            }

            result.IsSucceeded = true;
            return result;
        }

        public CustomResult<Users> InsertOrUpdate(Users user)
        {
            CustomResult<Users> result = new CustomResult<Users>() { IsSucceeded = false };
            UserRepository userRepository = new UserRepository();
            Users userResult = new Users();
            if (user.Id > 0)
            {

            }
            userResult = userRepository.InsertOrUpdate(user);
            result.TransactionResult = userResult;
            return result;
        }
    }
}
