using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Memcache
{
    /*
     *<?xml version="1.0" encoding="utf-8" ?> 
<configuration> 
  <configSections> 
    <sectionGroup name="enyim.com"> 
      <section name="memcached" type="Enyim.Caching.Configuration.MemcachedClientSection, Enyim.Caching" /> 
    </sectionGroup> 
  </configSections> 
  <enyim.com protocol="Binary"> 
    <memcached> 
      <servers> 
        <add address="localhost" port="11121" /> 
        <!--<add address="localhost" port="11131" /> 
        <add address="localhost" port="11141" /> 
        <add address="localhost" port="11151" />--> 
      </servers> 
      <socketPool minPoolSize="10" maxPoolSize="100" connectionTimeout="00:00:10" deadTimeout="00:02:00" /> 
    </memcached> 
  </enyim.com> 
</configuration> 
     * *
         */
    public class JstMemcacheClient : IMemcache
    {
        private static MemcachedClient _client = new MemcachedClient();

        #region Get
        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return Get<object>(key);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return _client.Get<T>(key);
        }

        #endregion

        #region Set

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">值</param>
        /// <param name="minutes">失效时间（分钟单位）</param>
        /// <returns></returns>
        public bool Set(string key, object value, int minutes = 5)
        {
            return Set<object>(key, value, minutes);
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime">失效时间</param>
        /// <returns></returns>
        public bool Set(string key, object value, DateTime expireTime)
        {
            return Set<object>(key, value, expireTime);
        }

        public bool Set<T>(string key, T value, int minutes = 5)
        {
            return Set<T>(key, value, DateTime.Now.AddMinutes(minutes));
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime">失效时间</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, DateTime expireTime)
        {
            return _client.Store(StoreMode.Set, key, value, expireTime) && IsExist(key);
        } 
        #endregion

        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            return Get(key) != null;
        }
    }
}
