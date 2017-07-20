using Jst.Core.Ioc;
using Jst.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Log4net
{
    public class JstLog4NetModule : CoreComponentModule
    {
        public override void PreInit(IIocManager instance)
        {
            instance.RegisterType<JstCoreLog4net, IJstCoreLogs>(interceptor: false);
            base.PreInit(instance);
        }
    }
}
