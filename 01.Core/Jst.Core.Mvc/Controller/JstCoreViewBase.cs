using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Jst.Core.Mvc.Controller
{
    public class JstCoreViewBase<TModel> : WebViewPage<TModel>
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class JstCoreViewBase : JstCoreViewBase<object>
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
