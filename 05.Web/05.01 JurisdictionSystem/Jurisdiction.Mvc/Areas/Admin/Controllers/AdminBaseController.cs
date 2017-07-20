using Jst.Core.Mvc.Controller;
using Jurisdiction.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jst.Core.Cache;
using Jst.Core.Ioc;

namespace Jurisdiction.Mvc.Areas.Admin.Controllers
{
    public abstract class AdminBaseController : BaseController
    {
        public AdminBaseController()
        {
        }
    }
}