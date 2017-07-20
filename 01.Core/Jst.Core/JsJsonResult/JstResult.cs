using Jst.Core.JstException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.JsJsonResult
{
    /// <summary>
    /// ajax请求返回基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JstResult<T>
    {
        public JstResult()
        {
            Status = false;
            Result = 0;
            Message = string.Empty;
            Exception = null;
        }

        /// <summary>
        /// 调用状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 请求结果
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 结果消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public JstCoreException Exception { get; set; }

    }

    /// <summary>
    /// ajax请求返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JstResult : JstResult<object>
    {

    }
}
