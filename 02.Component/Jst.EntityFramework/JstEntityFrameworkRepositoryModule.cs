using Jst.Core.Ioc;
using Jst.EntityFramework.Extensions;
using System.Reflection;

namespace Jst.EntityFramework
{
    public class JstEntityFrameworkRepositoryModule : BusyComponentModule
    {
        public override  void PreInit(IIocManager instance)
        {
            //instance.RegisterAssemblies(Assembly.GetCallingAssembly());
            instance.RegisterDbContext(Assembly.GetCallingAssembly());
            instance.RegsiterRepositories(Assembly.GetCallingAssembly());
            instance.RegisterAssemblies(Assembly.GetCallingAssembly());
            base.PreInit(instance);
        }
    }
}
