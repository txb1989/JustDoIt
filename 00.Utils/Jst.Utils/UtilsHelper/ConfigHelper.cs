using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Utils.UtilsHelper
{
    /// <summary>
    /// 配置帮助类
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// 获得配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 获得配置，并转化数据格式，如果失败则返回默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defalutValue"></param>
        /// <returns></returns>
        public static T GetConfigSetting<T>(string key,T defalutValue)
        {
            string strValue = GetConfigSetting(key);
            T value = defalutValue;
            try
            {
                value = (T)Convert.ChangeType(strValue, typeof(T));
            }
            catch (Exception)
            {
                value = defalutValue;
            }
            return value;
        }

    }
}
