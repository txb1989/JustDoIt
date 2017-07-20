using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace Jst.Utils.xConfig
{
    /// <summary>
    /// 配置读取接口
    /// </summary>
    public interface ISetting
    {
        #region  取配置文件值方法
        /// <summary>
        /// 根据key取配置文件的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        T GetSettingValue<T>(string key, T defValue = default (T));

        /// <summary>
        /// 根据key取配置文件的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetSettingValue(string key);

        /// <summary>
        /// 获得连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetConnectString(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string this[string key] { get; } 
        #endregion

        #region 缓存方法
        /// <summary>
        /// 刷新配置
        /// </summary>
        void DoReresh(); 
        #endregion


    }
}