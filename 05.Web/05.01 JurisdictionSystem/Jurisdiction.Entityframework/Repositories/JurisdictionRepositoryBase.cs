using Jst.Core.Entities;
using Jst.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jst.EntityFramework;

namespace Jurisdiction.Entityframework.Repositories
{
    public class JurisdictionRepositoryBase<TPrimaryKey, TEntity> : EfRepositoryBase<JurisdictionDbContext, TPrimaryKey, TEntity>
        where TPrimaryKey : struct
        where TEntity : EntityBase<TPrimaryKey>
    {
        public JurisdictionRepositoryBase(IDbContextProvider<JurisdictionDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

    }
    //public class JurisdictionRepositoryBase<TEntity> : JurisdictionRepositoryBase<long,  TEntity>, Jst.Core.IRepository<TEntity>
    //    where TEntity : EntityBase
    //{
    //    public JurisdictionRepositoryBase(IDbContextProvider<JurisdictionDbContext> dbContextProvider) : base(dbContextProvider)
    //    {
    //    }
    //}
}
