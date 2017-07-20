

using Jst.Core.Ioc;
using System.Reflection;

namespace Jst.Core
{
    public class JstCoreInitialization
    {
        /// <summary>
        /// 初始化入口代码
        /// </summary>
        public static void Initialize()
        {
            IocManager.Instance.InitIoc();
        }

    }
}
