using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Utils.UtilsHelper
{
    /// <summary>
    /// 时间操作的帮助类
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 时间转时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ConvertDateTimeToLong(DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(dt - startTime).TotalSeconds;
        }

        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public static DateTime ConvertLongToDateTime(long times)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(times + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }

    }
}
