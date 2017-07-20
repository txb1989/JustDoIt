using Jst.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uow.Test
{
    public class MyDBContext : JstDbContext
    {
        public MyDBContext() : base("Default")
        {
            //Database.SetInitializer<MyDBContext>(null);
            System.Data.Entity.Database.SetInitializer<MyDBContext>(null);
        }
        public virtual IDbSet<Uow.Test.Entities.Role> Roles { get; set; }

        public virtual IDbSet<Uow.Test.Entities.User> Users { get; set; }
    }
}
