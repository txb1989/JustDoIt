using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Cache
{
    public interface ICached : ISingleInstance
    {
        #region Set
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="minutes">失效时间（单位分钟）</param>
        bool Set<T>(string key, T value, int minutes = 5);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expireTime">过期时间</param>
        /// <returns></returns>
        bool Set<T>(string key, T value, DateTime expireTime);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="minutes">失效时间（单位分钟）</param>
        bool Set(string key, object value, int minutes = 5);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expireTime">过期时间</param>
        /// <returns></returns>
        bool Set(string key, object value, DateTime expireTime);
        #endregion

        #region Get
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        object Get(string key);

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        T Get<T>(string key);

        #endregion

        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsExist(string key);
    }
}
