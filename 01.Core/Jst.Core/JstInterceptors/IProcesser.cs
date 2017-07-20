
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.JstInterceptors
{
    /**
     *开始的时候设计考虑由调用者自己决定是否调用方法，但是考虑一个方法可能被多个多个拦截器拦截处理
     * 每个拦截器拦截后都处理一次，那这个方法就执行多次了，加参数由最后一个调用者调用，但是调用者不-
     * 知道自己会在第几个调用，最简单阻断方法执行的方法就是抛异常
     */
    /// <summary>
    /// Castle拦截器拦截后同意处理的程序
    /// </summary>
    public  interface IProcesser
    {
        /// <summary>
        /// 处理前
        /// </summary>
        /// <returns></returns>
        bool Processing();

        /// <summary>
        /// 处理后
        /// </summary>
        /// <returns></returns>
        bool Processed();
    }
}
