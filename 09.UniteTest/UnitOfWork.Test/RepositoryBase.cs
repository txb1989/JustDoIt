using Jst.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jst.EntityFramework;
using Jst.Core.Entities;
using Jst.Core;
using UnitOfWork.Test.Entities;

namespace UnitOfWork.Test.Repositories
{
    public interface ICustomerRepository<TPrimaryKey, TEntity> : IRepository<TPrimaryKey, TEntity> { }
    

    public interface IOpenUserRepository<TPrimaryKey, TEntity> : IRepository<TPrimaryKey, TEntity> { }

    public class CustomerRepositoryBase<TPrimaryKey, TEntity> 
        : EfRepositoryBase<CustomerDbContext, TPrimaryKey, TEntity>, ICustomerRepository<TPrimaryKey, TEntity>
        where TEntity : EntityBase<TPrimaryKey>
        where TPrimaryKey : struct
    {
        public CustomerRepositoryBase(IDbContextProvider<CustomerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    

    public class OpenUserRespositoryBase<TPrimaryKey, TEntity>
        : EfRepositoryBase<OpenUserDbContext, TPrimaryKey, TEntity>, IOpenUserRepository<TPrimaryKey, TEntity>
        where TEntity : EntityBase<TPrimaryKey>
        where TPrimaryKey : struct
    {
        public OpenUserRespositoryBase(IDbContextProvider<OpenUserDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

}
