using Jst.Utils.EnumExt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Jst.Utils.UtilsHelper
{
    /// <summary>
    /// 枚举的帮助类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 遍历获取枚举的值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<EnumItem> GetEnumList(Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
            List<EnumItem> list = new List<EnumItem>();
            foreach (var field in fields)
            {
                string description = string.Empty;
                var attribute = field.GetCustomAttribute<DescriptionAttribute>(false); //Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                var ignoreAttribute = field.GetCustomAttribute<EnumIgnoreAttribute>(false); //Attribute.GetCustomAttribute(field, typeof(EnumIgnoreAttribute), false);
                if (attribute != null && attribute is DescriptionAttribute
                    && !( ignoreAttribute.IsNotNull() && ignoreAttribute is EnumIgnoreAttribute 
                    && !ignoreAttribute.Cast<EnumIgnoreAttribute>().IsIgnore)//(((EnumIgnoreAttribute)ignoreAttribute).IsIgnore)
                    )
                {
                    description = ((DescriptionAttribute)attribute).Description;
                    var objValue = field.GetValue(null);
                    string v = objValue.Cast<int>().ToString(); //((int)field.GetValue(null)).ToString();
                    EnumItem item = new EnumItem() {
                        Description = description,
                        IValue = ConvertHelper.StrToInt(v,-1),
                        Value = field.GetValue(null).Cast<Enum>(),
                        ValueString = objValue.ToString()
                    };
                    list.Add(item);
                }
            }
            return list;

        }

        /// <summary>
        /// 遍历获取枚举的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumItem> GetEnumList<T>()
        {
            Type type = typeof(T);
            return GetEnumList(type);
        }
    }
}
