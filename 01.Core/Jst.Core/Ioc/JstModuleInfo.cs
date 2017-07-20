using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Ioc
{
    public class JstModuleInfo
    {
        /// <summary>
        /// 程序集
        /// </summary>
        public Assembly AssemblyInfo { get; set; }

        /// <summary>
        /// 实例
        /// </summary>
        public IJstAppModule Instance { get; set; }
        
        /// <summary>
        /// 模块名称，采用JstAppModule的类名
        /// </summary>
        public string ModuleName { get; set; }

        public int SortNo { get; set; }
    }
}
