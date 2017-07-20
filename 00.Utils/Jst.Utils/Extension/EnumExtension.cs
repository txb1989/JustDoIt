using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        public static string xGetDescription(this System.Enum value)
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
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr.IsNotNull()) return attr.Description;
                }
            }
            return string.Empty;
        }


    }
}
