using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Jst.FileSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FileUpload",
                url: "File",
                defaults: new { controller = "FileUpload", action = "UploadFile", id = UrlParameter.Optional });

            routes.MapRoute(
              name: "ImageUpload",
              url: "Image",
              defaults: new { controller = "FileUpload", action = "UploadImage", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
