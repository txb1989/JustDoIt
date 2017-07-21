using System;

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
        public static long ConvertTimeToStamp(DateTime dt)
        {
            //System.DateTime startTime = TimeZoneInfo.Local.GetUtcOffset().ToLocalTime(new System.DateTime(1970, 1, 1));
            DateTime dtStart = new DateTime(1970, 1, 1).Add(TimeZoneInfo.Local.BaseUtcOffset);
            return (long)(dt - dtStart).TotalSeconds;
        }

        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public static DateTime ConvertStampToTime(long times)
        {
            DateTime dtStart =  new DateTime(1970, 1, 1).Add(TimeZoneInfo.Local.BaseUtcOffset); //TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));//当前时区的时间
            long lTime = long.Parse(times + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }

    }
}
