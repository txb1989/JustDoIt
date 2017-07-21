using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Utils.Extension
{
    /// <summary>
    /// 时间操作的扩展方法
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 转化成常用的时间展示格式(yyyy-MM-dd HH:mm:ss)
        /// 将时间转化成 yyyy-MM-dd HH:mm:ss 格式的字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="formate"></param>
        /// <returns></returns>
        public static string ToCmString(this DateTime dt,string formate= "yyyy-MM-dd HH:mm:ss")
        {
            return dt.ToString(formate);
        }

        
    }
}
