using Jst.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Test.Entities;

namespace UnitOfWork.Test
{
    public class CustomerDbContext : JstDbContext
    {
        public CustomerDbContext() : base("Con1")
        {

            Database.SetInitializer<CustomerDbContext>(null);
        }

        public virtual IDbSet<Customer> Customers { get; set; }
    }

    public class OpenUserDbContext : JstDbContext
    {
        public OpenUserDbContext() : base("Con2") { Database.SetInitializer<OpenUserDbContext>(null); }

        public virtual IDbSet<OpenUser> OpenUsers { get; set; }
    }
}
