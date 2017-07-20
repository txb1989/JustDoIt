using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jst.FileSite.Models
{
    public class UploadResult
    {
        public bool success { get; set; }

        public string msg { get; set; }

        public string path { get; set; }
    }
}