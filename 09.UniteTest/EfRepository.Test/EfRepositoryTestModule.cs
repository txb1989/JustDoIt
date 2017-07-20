using Jst.Core.Ioc;
using Jst.EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EfRepository.Test
{
    public class EfRepositoryTestModule : JstAppModuleBase
    {
        public override void PreInit(IIocManager instance)
        {
            instance.RegisterDbContext(Assembly.GetExecutingAssembly());
            instance.RegsiterRepositories(Assembly.GetExecutingAssembly());
            instance.RegisterAssemblies(Assembly.GetExecutingAssembly());
            base.PreInit(instance);
        }
    }
}
