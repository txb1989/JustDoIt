using Jst.Core.Cache;
using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Memcache
{
    public class JstMemcacheModule : CoreComponentModule
    {
        public override void PreInit(IIocManager instance)
        {
            // if(!instance.IsRegister<ICached>()) instance.RegisterType<JstMemcacheClient, ICached>();
            //instance.RegisterTypePreserveExistingDefaults<JstMemcacheClient, ICached>();
            //instance.RegisterType<JstMemcacheClient, IMemcache>();
            instance.RegisterType<JstMemcacheClient, ICached>("MemCached");
            instance.RegisterType<JstMemcacheClient, ICached>();
            base.PreInit(instance);
        }
    }
}
