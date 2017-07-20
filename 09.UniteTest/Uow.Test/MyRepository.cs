using Jst.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jst.EntityFramework;
using Jst.Core.Entities;
using Jst.Core;

namespace Uow.Test
{
    public class MyRepository<TEntity> : EfRepositoryBase<MyDBContext,long,  TEntity> where TEntity : EntityBase
    {
        public MyRepository(IDbContextProvider<MyDBContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
