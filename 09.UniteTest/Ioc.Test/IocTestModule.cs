using Ioc.Test.Services;
using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Test
{
    public class IocTestModule : JstAppModuleBase
    {
        public  override void PreInit(IIocManager instance)
        {
            instance.RegisterGeneric(typeof(MyServiceGeneric<>), typeof(IServiceGeneric<>));
            instance.RegisterType(typeof(MyServiceGeneric2), typeof(IServiceGeneric2<int>));
            instance.RegisterGeneric(typeof(MyObjectProvider<>), typeof(IObjectProvider<>));
            instance.RegisterGeneric(typeof(RepositoryA<,>), typeof(IRepository<,>), "RepositoryA");
            instance.RegisterGeneric(typeof(RepositoryB<,>),typeof(IRepository<,>), "RepositoryB");
            List<int> list = new List<int>();
            instance.RegisterTypeAsObject(false, Assembly.GetExecutingAssembly().GetTypes().Where(c=>typeof(MyDbObject).IsAssignableFrom(c)).ToArray());
            instance.RegisterAssemblies(Assembly.GetExecutingAssembly());
            base.PreInit(instance);
        }
    }
}
