using Snowflake.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Utils.UtilsHelper
{
    /// <summary>
    /// 雪花生成算法帮助类
    /// </summary>
    public class SnowflakeWorkerHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private static IdWorker worker = new IdWorker(1,1);

        /// <summary>
        ///获得id
        /// </summary>
        /// <returns></returns>
        public static long GetId()
        {
            return worker.NextId();
        }

    }
}
