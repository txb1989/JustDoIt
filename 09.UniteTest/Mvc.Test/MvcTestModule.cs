using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mvc.Test
{
    public class MvcTestModule : JstAppModuleBase
    {
        public override void PreInit(IIocManager instance)
        {
            instance.RegisterAssemblies(Assembly.GetExecutingAssembly());
            base.PreInit(instance);
        }
    }
}