using Jst.Core.Cache;
using Jst.Core.Ioc;
using Jst.Core.Mvc.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jurisdiction.Mvc.Controllers
{
    public class BaseController : JstCoreControllerBase
    {
        protected readonly ICached cache;
        public BaseController()
        {
            cache = IocManager.Instance.Resolve<ICached>();
        }
    }
}