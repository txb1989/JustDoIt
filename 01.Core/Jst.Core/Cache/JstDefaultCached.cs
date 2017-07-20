using Jst.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jst.Core.Cache
{
    /**
    *之所以要定义一个接口实现，是考虑这样一个问题，如果我想保持MemCached和默认缓存同时存在的话
    * 最初我的想法是用ICached注册为默认的实现，Memched自己定义一个接口集成ICached病实现此接口
    * 但是出现的问题是我这个程序集注册，ICached始终被注册成了Memcached的实现，默认的实现已经被
    * 覆盖掉了。没有办法，顶一个默认的接口，集成资ICached接口，如果使用IJstDefaultCached接口就是
    * 默认的实现，如果使用ICached接口就是Memcached的实现。以后如果增加Redis的实现也需要一个空
    * 接口继承ICached，然后再实现Redis的缓存
    */
    /// <summary>
    /// 默认的缓存实现
    /// </summary>
    public interface IJstDefaultCached : ICached
    {

    }

    /// <summary>
    /// 默认的缓存实现，采用内存字典存储
    /// </summary>
    public class JstDefaultCached : IJstDefaultCached
    {
        public static object _lockObj = new Lazy<object>().Value;

        /// <summary>
        /// 定时刷新缓存,一秒钟刷新一次字典，移除过期的数据
        /// </summary>
        private static Timer _timmer = null;

        static JstDefaultCached()
        {
            _timmer = new Timer((state) =>
            {
                foreach (string key in _cacheDictionary.Keys)
                {
                    CacheItem item = null;
                    if (_cacheDictionary.TryGetValue(key, out item))
                    {
                        if (!item.CheckIsNull() && item.ExpireTime >= DateTime.Now)
                        {
                            continue;
                        }
                        else
                        {
                            _cacheDictionary.TryRemove(key, out item);
                        }
                    }
                }
            }, null, TimeSpan.Zero, new TimeSpan(TimeSpan.TicksPerSecond));
        }

        public static ConcurrentDictionary<string, CacheItem> _cacheDictionary = new ConcurrentDictionary<string, CacheItem>();

        #region Get方法
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
        /// 取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            CacheItem item = null;
            T defaultValue = default(T);
            if (_cacheDictionary.TryGetValue(key, out item))
            {
                if (item.IsNotNull())
                {
                    return item.Cast<T>();
                }
            }
            return defaultValue;
        }
        #endregion

        /// <summary>
        /// 检查key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            return _cacheDictionary.ContainsKey(key);
        }

        #region Set 方法
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public bool Set(string key, object value, DateTime expireTime)
        {
            return Set<object>(key, value, expireTime);
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public bool Set(string key, object value, int minutes = 5)
        {
            return Set<object>(key, value, minutes);
        }


        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, int minutes = 5)
        {
            return Set<T>(key, value, DateTime.Now.AddMinutes(minutes));
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, DateTime expireTime)
        {
            CacheItem item = new CacheItem()
            {
                ExpireTime = expireTime,
                Key = key,
                Value = value
            };
            _cacheDictionary.AddOrUpdate(key, item, (mkey, olditem) =>
            {
                olditem.ExpireTime = expireTime;
                olditem.Key = key;
                olditem.Value = value;
                return olditem;
            });
            return IsExist(key);
        }
        #endregion
    }

    /// <summary>
    /// 缓存项
    /// </summary>
    public class CacheItem
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime ExpireTime { get; set; }
    }
}
