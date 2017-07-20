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
        /// 检查是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Obsolete("请使用IsNull方法")]
        public static bool CheckIsNull(this object obj)
        {
            return IsNull(obj);
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

        /// <summary>
        /// 是否为null或DBNull.Value
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是返回true,否则返回false</returns>
        public static bool IsNullOrDbNull(this object value)
        {
            return value == null || value == DBNull.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        public static void CheckNullOrDbNull(this object value, string parameterName = "")
        {
            if (value.IsNullOrDbNull()) throw new ArgumentException(parameterName);
        } 

        /// <summary>
        /// 是否是某个类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this object obj)
        {
            return obj.Is(typeof(T));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Is(this object obj,Type type)
        {
            //return type.IsInstanceOfType(obj) ;
            //return type.IsAssignableFrom(obj.GetType());
            return type.IsInstanceOfType(obj) || type.IsAssignableFrom(obj.GetType());
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

        /// <summary>
        /// xml序列号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToXml(this object obj)
        {
            string strXml = string.Empty;
            if (obj != null)
            {
                MemoryStream Stream = new MemoryStream();
                XmlSerializer xml = new XmlSerializer(obj.GetType());
                try
                {
                    //序列化对象
                    xml.Serialize(Stream, obj);
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
                Stream.Position = 0;
                StreamReader sr = new StreamReader(Stream);
                string str = sr.ReadToEnd();

                sr.Dispose();
                Stream.Dispose();

                return str;

            }
            return strXml;
        }

        /// <summary>
        /// 序列化成二进制
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] SerializeObject(this object obj)
        {
            if (obj == null)
                return null;
            MemoryStream ms = new MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }

        /// <summary>
        /// 二进制反序列化对象
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(this byte[] bytes)
        {
            T obj = default(T);
            if (bytes == null)
                return obj;
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            obj = (T)formatter.Deserialize(ms); //formatter.Deserialize(ms);
            ms.Close();
            return obj;
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