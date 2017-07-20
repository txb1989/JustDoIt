
using System.Web.Mvc;

namespace Jst.Core.Mvc.Controller
{
    public class JstCoreControllerBase : System.Web.Mvc.Controller
    {

        protected override System.Web.Mvc.JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {

            return new RequestResult.JsonResult()
            {
                ContentEncoding = contentEncoding,
                ContentType = contentType,
                Data = data,
                JsonRequestBehavior = behavior
            };
        }
        
        protected System.Web.Mvc.JsonResult JsonFormat(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new RequestResult.JsonResult()
            {
                ContentEncoding = contentEncoding,
                ContentType = contentType,
                Data = data,
                JsonRequestBehavior = behavior
            };
        }

    }
}
