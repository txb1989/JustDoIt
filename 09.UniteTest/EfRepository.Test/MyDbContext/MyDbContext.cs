using EfRepository.Test.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRepository.Test.MyDbContext
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() :base("Default")
        {
           
        }

        public IDbSet<OpenUser> OpenUsers { get; set; }
    }

    public class OpenUserDbContext : DbContext
    {
        public OpenUserDbContext() : base("Con1")
        {

        }
        public IDbSet<OpenUser> OpenUsers { get; set; }
    }

    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext() : base("Con1")
        {

        }
        public IDbSet<Customer> Customers { get; set; }
    }
}
