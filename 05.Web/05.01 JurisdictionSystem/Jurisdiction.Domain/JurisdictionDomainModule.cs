using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Domain
{
    public class JurisdictionDomainModule : BusyComponentModule
    {
        public override void PreInit(IIocManager instance)
        {
            base.PreInit(instance);
        }
    }
}
