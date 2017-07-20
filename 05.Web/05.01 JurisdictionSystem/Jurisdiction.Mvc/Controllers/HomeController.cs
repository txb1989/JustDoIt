using Jst.Core.Mvc.Controller;
using Jurisdiction.Application.Dto;
using Jurisdiction.Application.Interface;
using Jurisdiction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jurisdiction.Mvc.Controllers
{
    public class HomeController : JstCoreControllerBase
    {
        private readonly IRoleApplicationService roleService;
        public HomeController(IRoleApplicationService _roleSerivce)
        {
            this.roleService = _roleSerivce;
        }

        public ActionResult Index()
        {
            List<RoleDto> list = roleService.GetAllRole();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}