using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.JstInterceptors
{
    /// <summary>
    /// 拦截器中断异常
    /// </summary>
    public class InterruptException : Exception
    {

        public InterruptException() { }

        public InterruptException(string msg):base(msg) { }

    }

    
}
