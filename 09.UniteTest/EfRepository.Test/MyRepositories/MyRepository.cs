using Jst.Core.Entities;
using Jst.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfRepository.Test.MyDbContext;
using Jst.EntityFramework;
using EfRepository.Test.Entities;
using Jst.Core.Attributes;

namespace EfRepository.Test.MyRepositories
{
    public class MyRepository<TPrimaryKey, TEntity>
        : EfRepositoryBase<MyDbContext.MyDbContext, TPrimaryKey, TEntity>
          where TPrimaryKey : struct
        where TEntity : EntityBase<TPrimaryKey>
    {
        public MyRepository(IDbContextProvider<MyDbContext.MyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    [RegisterAliasName("CustomerRepository")]
    public class CustomerRepositoryBase<T> : EfRepositoryBase<MyDbContext.CustomerDbContext, int, T> where T : EntityBase<int>
    {
        public CustomerRepositoryBase(IDbContextProvider<CustomerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    [RegisterAliasName("OpenUserRepository")]
    public class OpenUserRepositoryBase<T> : EfRepositoryBase<MyDbContext.OpenUserDbContext,int, T> where T : EntityBase<int>
    {
        public OpenUserRepositoryBase(IDbContextProvider<OpenUserDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class CustomerRepository : CustomerRepositoryBase<Customer>, IMyRepository
    {
        public CustomerRepository(IDbContextProvider<CustomerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
