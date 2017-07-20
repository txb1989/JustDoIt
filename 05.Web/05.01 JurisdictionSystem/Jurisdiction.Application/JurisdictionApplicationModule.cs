using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Application
{
    public class JurisdictionApplicationModule : BusyComponentModule
    {
        public override void PreInit(IIocManager instance)
        {
            base.PreInit(instance);
        }
    }
}
