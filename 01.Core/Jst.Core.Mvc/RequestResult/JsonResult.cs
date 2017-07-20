using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Jst.Core.Mvc.RequestResult
{
    public class JsonResult : System.Web.Mvc.JsonResult
    {
        public string JsonTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public JsonResult()
        {
            this.ContentEncoding = Encoding.UTF8;
            this.ContentType = "application/json";
            this.JsonTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data != null)
            {
                var dateConvert = new IsoDateTimeConverter();
                dateConvert.DateTimeFormat = this.JsonTimeFormat;
                //var enumConvert = new StringEnumConverter
                string jsonString = JsonConvert.SerializeObject(this.Data, Formatting.Indented, new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters = new List<JsonConverter>() { dateConvert }
                });
                response.Write(jsonString);
            }
        }

    }
}
