using Jst.Core.Ioc;
using Jst.Core.Uow;
using Jst.Utils;
using Jst.Utils.Extension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Jst.EntityFramework.Uow
{
    [Serializable]
    public class EfUnitOfWork : DefaultUnitOfWork
    {
        protected TransactionScope trans = null;
        protected IDictionary<string, DbContext> ActiveDbContexts { get; private set; }

        //private const string DbContextKey = "Jst.Entityframework.DbContext";

        public EfUnitOfWork() {
            Id = Guid.NewGuid().ToString("N");
            ActiveDbContexts = new Dictionary<string, DbContext>();
        }

        public override void Begin(UnitOfWorkOptions option)
        {
            if (option.IsTransaction)  trans = new TransactionScope(); 
        }

        public override void Commit()
        {
            ActiveDbContexts.Foreach(item =>
            {
                item.Value.SaveChanges();
            });
            trans.Complete();
        }

        public override void RollBack()
        {
        }
        public override void Dispose()
        {
            if(trans.IsNotNull()) trans.Dispose();
            ActiveDbContexts.Foreach(item =>
            {
                item.Value.Dispose();
            });
            ActiveDbContexts.Clear();
        }


        public TDbContext GetOrCreateDbContext<TDbContext>() where TDbContext : DbContext
        {
            Type contextType = typeof(TDbContext);
            string contextKey = contextType.FullName;
            DbContext context = null;
            if(ActiveDbContexts.TryGetValue(contextKey,out context))
            {
                return (TDbContext)context;
            }

            TDbContext dbContext = IocManager.Instance.Resolve<TDbContext>();
            if (dbContext.IsNotNull())
            {
                ActiveDbContexts.Add(contextKey, dbContext);
            }
            return dbContext;
        }
        
    }
}
