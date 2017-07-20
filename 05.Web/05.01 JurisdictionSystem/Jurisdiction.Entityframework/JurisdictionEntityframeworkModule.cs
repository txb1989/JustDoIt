using Jst.Core.Ioc;
using Jst.EntityFramework;
using Jst.EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Entityframework
{
    public class JurisdictionEntityframeworkModule: JstEntityFrameworkRepositoryModule
    {
        public override void PreInit(IIocManager instance)
        {
            base.PreInit(instance);
        }
    }
}
