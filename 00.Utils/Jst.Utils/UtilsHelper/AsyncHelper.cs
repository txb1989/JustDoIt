using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Jst.Utils.UtilsHelper
{
    /// <summary>
    /// Provides some helper methods to work with async methods.
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// 检查方法是否是一个异步方法
        /// </summary>
        /// <param name="method">A method to check</param>
        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }      
    }
}
