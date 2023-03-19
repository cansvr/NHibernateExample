using FluentNHibernate.Mapping;
using NHibernateExample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Data.Entities
{
    public class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.UserName);
        }
    }
}
