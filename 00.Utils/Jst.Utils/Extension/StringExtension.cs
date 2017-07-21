using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Jst.Utils.Extension
{
    /// <summary>
    /// string的扩展方法
    /// </summary>
    public static class StringExtension
    {

        #region 转换方法

        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns></returns>
        public static List<string> GetString2Array(this string str, char[] speater, bool toLower =false)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(speater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != speater.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }
        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns></returns>
        public static List<string> GetString2Array(this string str, char speater, bool toLower = false)
        {
            return GetString2Array(str, new char[] {speater}, toLower);
        }
        /// <summary>
        /// 字符串转数组
        /// </summary>
        /// <typeparam name="T">转换后类型</typeparam>
        /// <param name="str">字符串</param>
        /// <param name="separates">分割字符</param>
        /// <param name="options">是否去空字符串</param>
        /// <returns>转换后的类型List</returns>
        public static List<T> GetString2Array<T>(this string str, char[] separates,
            StringSplitOptions options = StringSplitOptions.None)
        {
            List<T> list = new List<T>();
            Type type = typeof(T);
            if (string.IsNullOrWhiteSpace(str)) return list;
            if (separates != null && separates.Length > 0)
            {
                List<string> arrays = str.GetString2Array(separates);
                if (arrays!=null && arrays.Count > 0)
                {
                    foreach (string item in arrays)
                    {
                        list.Add((T)Convert.ChangeType(item, typeof(T)));
                    }
                }
            }
            else
            {
                list.Add((T)Convert.ChangeType(str, typeof(T)));
            }

            return list;
        }

        /// <summary>
        /// 字符串转数据
        /// </summary>
        /// <typeparam name="T">转换后类型</typeparam>
        /// <param name="str">字符串</param>
        /// <param name="separate">分割字符</param>
        /// <param name="options">是否去空字符串</param>
        /// <returns>转换后的类型List</returns>
        public static List<T> GetString2Array<T>(this string str, char separate = ',',
            StringSplitOptions options = StringSplitOptions.None)
        {
            return str.GetString2Array<T>(new char[] { separate }, options);
        }

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSbc(this string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string ToDbc(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        } 
        #endregion
        
        #region 验证方法
        /// <summary>
        /// 判断一个字符串是否为空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// 
        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 判断字符串不为空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 判断是否是邮箱字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static bool IsEMail(this string s, RegexOptions option = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(s, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", option);
        }

        /// <summary>
        /// 判断字符串是否是整数
        /// PS:忽略大小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDigit(this string s)
        {
            return Regex.IsMatch(s, @"^\d+$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 检查日期，假如闰年的判断（参考：http://www.cnblogs.com/jay-xu33/archive/2009/01/08/1371953.html）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string s)
        {
            string pattern =
                @"((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(s);
        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIp(this string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 是否是手机号
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsMobilePhone(this string number)
        {
            if (string.IsNullOrEmpty(number) || string.IsNullOrEmpty(number.Trim()))
            {
                return false;
            }
            Regex reg = new Regex("^(86)*1[0-9]{10}$");
            //多个判断，错误的情况少走正则匹配耗掉时间
            if ((number.Length == 11 || number.Length == 13) && reg.IsMatch(number.Trim()))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region  替换

        /// <summary>
        /// HTML转行成TEXT
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlToTxt(this string strHtml)
        {
            string[] aryReg ={
            @"<script[^>]*?>.*?</script>",
            @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
            @"([\r\n])[\s]+",
            @"&(quot|#34);",
            @"&(amp|#38);",
            @"&(lt|#60);",
            @"&(gt|#62);", 
            @"&(nbsp|#160);", 
            @"&(iexcl|#161);",
            @"&(cent|#162);",
            @"&(pound|#163);",
            @"&(copy|#169);",
            @"&#(\d+);",
            @"-->",
            @"<!--.*\n"
            };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, string.Empty);
            }

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");


            return strOutput;
        }

        /// <summary>
        /// SQL语句过滤
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public static string SqlSafeString(this string str, bool isDel = false)
        {
            if (isDel)
            {
                str = str.Replace("'", "");
                str = str.Replace("\"", "");
                return str;
            }
            str = str.Replace("'", "&#39;");
            str = str.Replace("\"", "&#34;");
            return str;
        }
        #endregion

        #region Json

        

        /// <summary>
        /// 字符串反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(this string strJson)
        {
            T obj = default(T);
            if (strJson.IsEmpty()) return obj;
            obj = JsonConvert.DeserializeObject<T>(strJson);
            return obj;
        }

        #endregion
        
    }
}