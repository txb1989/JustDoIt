using Autofac.Integration.Mvc;
using Jst.Core.Ioc;
using Jst.Core.Mvc.Extension;
using System.Reflection;
using System.Web;

namespace Jst.Core.Mvc
{
    public class JstCoreMvcApplication: HttpApplication
    {

        protected virtual void Application_Start()
        {
            IocManager.Instance.RegisterControllers(Assembly.GetCallingAssembly());
            JstCoreInitialization.Initialize();
            IocManager.Instance.SetDependency();
        }

    }
}
