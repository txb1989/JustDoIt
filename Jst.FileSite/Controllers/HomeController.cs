using Jst.Core.Mvc.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jst.FileSite.Controllers
{
    public class HomeController : JstCoreControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }


        public ActionResult UploadTest()
        {
            return View();
        }


        public ActionResult PagerTest()
        {

            return View();
        }


        public JsonResult Testjson()
        {
            return Json(new {
                Name = "txb1989",
                Age = 27,
                Sex = EnumSex.Male,
                CreateTime = DateTime.Now,
            }, JsonRequestBehavior.AllowGet);
        }

    }

    enum EnumSex
    {
        Male,
        Female
    }
}