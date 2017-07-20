using Jst.Core.Ioc;
using Jst.Core.Uow;
using Jst.EntityFramework.Uow;
using Jst.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.EntityFramework
{
    public class DbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : DbContext
    {

        private readonly IUniteOfWorkManager uniteOfWorkManager;

        public DbContextProvider(IUniteOfWorkManager manger)
        {
            this.uniteOfWorkManager = manger;
        }

        public TDbContext GetDbContext() 
        {
            // return IocManager.Instance.Resolve<TDbContext>();
            //if (uniteOfWorkManager.IsNotNull())
            //{ }
            //TDbContext context = uniteOfWorkManager.Current.GetDbContext<TDbContext>();
            TDbContext context = uniteOfWorkManager.GetUnitOfWork().GetDbContext<TDbContext>();
            return context;
        }
    }
}
