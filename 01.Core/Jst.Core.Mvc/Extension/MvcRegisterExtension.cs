using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace Jst.Core.Mvc.Extension
{
    public static class MvcRegisterExtension
    {

        public static void RegisterControllers(this IIocManager instance,params Assembly[] assiblies )
        {
            instance.OperateBuilder(_builder =>
            {
                _builder.RegisterControllers(assiblies);
            });
        }

        public static void SetDependency(this IIocManager instance)
        {
            instance.OperateContainner(containner =>
            {
                DependencyResolver.SetResolver(new AutofacDependencyResolver(containner));
            });
        }

    }
}
