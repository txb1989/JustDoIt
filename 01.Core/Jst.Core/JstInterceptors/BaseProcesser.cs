using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Jst.Core.JstInterceptors
{
    /// <summary>
    /// 拦截器处理程序，此类没有做任何处理，扩展的话可以继承此类也可以实现IProcesser接口
    /// </summary>
    public class BaseProcesser : Attribute, IProcesser
    {
        /// <summary>
        /// 操作前执行
        /// </summary>
        /// <returns></returns>
        public virtual bool Processing()
        {
            return true;
        }

        /// <summary>
        /// 操作后执行
        /// </summary>
        /// <returns></returns>
        public virtual bool Processed()
        {
            return true;
        }
    }
}
