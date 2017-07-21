using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Jst.Utils
{
    /// <summary>
    /// 全局的扩展方法，慎重添加
    /// </summary>
    public static class GlobalExtension
    {
        #region 检查对象
        /// <summary>
        /// 检查是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// 检查是否为空，不为空范湖true
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }
        
        /// <summary>
        /// 检查是否为空，为空抛出异常
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="parameterName"></param>
        public static void CheckNull(this object obj, string parameterName = "")
        {
            if (obj == null) throw new ArgumentException(parameterName);
        }
        

        public static bool Is<T>(this object obj)
        {
            return obj is T;
        }

        #endregion

        #region 序列化
        /// <summary>
        /// 对象序列化Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            string strJson = string.Empty;
            if (obj != null)
            {
                strJson = JsonConvert.SerializeObject(obj);
            }
            return strJson;
        }
        
        #endregion

        #region 转换
        /// <summary>
        /// 将对象转换需要的类型（会判断能否转）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Cast<T>(this object obj)
        {
            T defaultValue = default(T);

            if (obj.IsNotNull() && obj.Is<T>())
            {
                defaultValue = (T)obj;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将对象转换需要的类型（不能转就会抛出异常）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T CastNoSafe<T>(this object obj)
        {
            T defaultValue = default(T);

            if (obj.IsNotNull())
            {
                defaultValue = (T)obj;
            }
            
            return defaultValue;
        }
        #endregion
    }
}