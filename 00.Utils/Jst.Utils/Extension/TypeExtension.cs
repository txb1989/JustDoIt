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
    /// 
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// 获得Description属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDescription(this Type type)
        {
          var attributes = type.GetCustomAttribute<DescriptionAttribute>(false);
            if (attributes.IsNotNull())
            {
                return attributes.Description;
            }
            return string.Empty;
        }
      
    }
}
