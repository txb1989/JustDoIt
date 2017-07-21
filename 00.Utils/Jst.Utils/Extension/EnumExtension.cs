using System;
using System.Reflection;
using System.ComponentModel;

namespace Jst.Utils.Extension
{
    /// <summary>
    /// 枚举扩展方法
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获得美剧的描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this System.Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    DescriptionAttribute attr = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
                    if (attr.IsNotNull()) return attr.Description;
                }
            }
            return string.Empty;
        }


    }
}
