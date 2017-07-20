using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jst.Core.Ioc;

namespace Uow.Test
{
    public class UowTestModule : Jst.EntityFramework.JstEntityFrameworkRepositoryModule
    {
        public override void PreInit(IIocManager instance)
        {
            base.PreInit(instance);
        }
    }
}
