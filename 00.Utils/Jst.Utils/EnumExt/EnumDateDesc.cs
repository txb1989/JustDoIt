using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Utils.EnumExt
{
    /// <summary>
    /// 枚举项
    /// </summary>
    public class EnumItem
    {
        /// <summary>
        /// Enum的Value值
        /// </summary>
        public Enum Value { get; set; }

        /// <summary>
        /// 如果是Int类型的枚举，这就是枚举对应的int，不是int类型的枚举，此值全未-1
        /// </summary>
        public int IValue { get; set; }

        /// <summary>
        /// Description属性的描述说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 枚举的字符串
        /// </summary>
        public string ValueString { get; set; }
    }

    /// <summary>
    /// 是否在遍历枚举的时候忽略该属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumIgnoreAttribute : Attribute
    {
        /// <summary>
        /// 是否忽略该项
        /// </summary>
        public bool IsIgnore { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="isIgnore"></param>
        public EnumIgnoreAttribute(bool isIgnore=true)
        {
            IsIgnore = IsIgnore;
        }
    }
}
