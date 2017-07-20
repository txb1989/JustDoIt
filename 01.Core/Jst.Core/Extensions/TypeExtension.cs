using Jst.Core.Attributes;
using Jst.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Extensions
{
    public static class TypeExtension
    {
        public static string GetAliasName(this Type type)
        {
            var attributes = type.GetCustomAttribute<RegisterAliasNameAttribute>(false);
            if (attributes.IsNotNull())
            {
                return attributes.AliasName;
            }
            return string.Empty;
        }
    }
}
