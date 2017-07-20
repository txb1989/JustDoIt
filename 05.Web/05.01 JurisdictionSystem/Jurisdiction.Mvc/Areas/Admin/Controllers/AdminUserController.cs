using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jst.Core.Cache;

namespace Jurisdiction.Mvc.Areas.Admin.Controllers
{
    public class AdminUserController : AdminBaseController
    {

        public AdminUserController()
        {

        }

        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
    }
}