using Jst.Core.Ioc;
using Jst.Core.Uow;
using Jst.EntityFramework.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.EntityFramework
{
    public class JstEntityFrameworkModule : CoreComponentModule
    {
        public override void PreInit(IIocManager instance)
        {
            instance.RegisterGeneric(typeof(DbContextProvider<>), typeof(IDbContextProvider<>),interceptor:false);
            instance.RegisterType<EfUnitOfWork, IUnitOfWork>(interceptor: false);
            base.PreInit(instance);
        }
    }
}
